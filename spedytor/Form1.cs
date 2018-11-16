using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace spedytor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!MySQL.getConfigured()) (new MysqlSettings()).ShowDialog();
            if (!MySQL.getConfigured()) this.Dispose();
            this.refreshDatabaseList();
            this.checkS3Options();
        }

        private void checkS3Options()
        {
            cSend.Enabled = (Properties.S3Settings.Default.AWS_ACCESS_KEY.Length > 0
                && Properties.S3Settings.Default.AWS_SECRET_KEY.Length > 0
                && Properties.S3Settings.Default.AWS_BUCKET_ID.Length > 0);
            if (!cSend.Enabled)
            {
                cSend.Checked = false;
            }
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            (new MysqlSettings()).ShowDialog();
            this.refreshDatabaseList();
            this.checkS3Options();
        }

        internal void refreshDatabaseList()
        {
            this.cbDatabaseName.Items.Clear();
            MySQL c = new MySQL("");
            MySqlDataReader dbs = c.select("SELECT TABLE_SCHEMA FROM information_schema.COLUMNS GROUP BY TABLE_SCHEMA;");
            while (dbs.Read())
            {
                this.cbDatabaseName.Items.Add(dbs.GetString(0));
            }
            this.cbDatabaseName.SelectedIndex = 0;
            dbs.Close();
        }

        private string getBucketID()
        {
            if (this.cSend.Checked && spedytor.Properties.S3Settings.Default.AWS_BUCKET_ID.Length > 0)
            {
                return spedytor.Properties.S3Settings.Default.AWS_BUCKET_ID;
            }
            return null;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            this.setControlState(false, null);
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string filePath = Path.Combine(fd.SelectedPath, this.cbDatabaseName.SelectedItem.ToString() + DateTime.Now.ToString("-yyyyMMdd-HHmmss") + ".sql");
                this.saveFile(filePath, this.cbDatabaseName.SelectedItem.ToString(), this.getBucketID());
            }
            this.setControlState(true, null);
        }

        private void saveFile(string filePath, string dbName, string s3Bucket = null)
        {
            try
            {
                MySQL c = new MySQL(dbName);
                c.backup(filePath);
                c.close();
                MessageBox.Show("Wyeksportowano pomyślnie do pliku: " + filePath, "Sukces eksportu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (s3Bucket != null)
                {
                    S3 s3Client = new S3();
                    s3Client.send(s3Bucket, filePath, dbName + ".sql");
                    MessageBox.Show("Wysłano!", "Sukces eksportu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd eksportu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setControlState(bool state, Control sender)
        {
            foreach (Control control in this.Controls)
            {
                if (control != sender)
                {
                    control.Enabled = state;
                }
            }
        }

        private void bTimer_Click(object sender, EventArgs e)
        {
            tInterval.Interval = Convert.ToInt32(nInterval.Value) * 60000;
            tInterval.Enabled = !tInterval.Enabled;
            if (tInterval.Enabled)
            {
                bTimer.Image = spedytor.Properties.Resources.stop;
                bTimer.Text = "Zatrzymaj";
                this.setControlState(false, bTimer);
                tInterval_Tick(null, null);
            }
            else
            {
                bTimer.Image = spedytor.Properties.Resources.refresh;
                bTimer.Text = "Zapisz co...";
                this.Enabled = true;
                this.setControlState(true, bTimer);
                this.repeatFilePath = null;
            }
        }

        private string repeatFilePath = null;

        private void tInterval_Tick(object sender, EventArgs e)
        {
            if (this.repeatFilePath == null)
            {
                FolderBrowserDialog fd = new FolderBrowserDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    this.repeatFilePath = fd.SelectedPath;
                }
                else
                {
                    bTimer_Click(null, null);
                    return;
                }
            }
            string filePath = Path.Combine(this.repeatFilePath, this.cbDatabaseName.SelectedItem.ToString() + DateTime.Now.ToString("-yyyyMMdd-HHmmss") + ".sql");
            this.saveFile(filePath, this.cbDatabaseName.SelectedItem.ToString(), this.getBucketID());
        }
    }
}
