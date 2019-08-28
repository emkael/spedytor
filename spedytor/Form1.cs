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
        const string LOG_FILENAME = "spedytor.log";

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
            String directory = spedytor.Properties.Settings.Default.DIRECTORY;
            if (!Directory.Exists(directory))
            {
                directory = "";
                spedytor.Properties.Settings.Default.DIRECTORY = "";
            }
            if (directory.Length == 0)
            {
                FolderBrowserDialog fd = new FolderBrowserDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    directory = fd.SelectedPath;
                }
                else
                {
                    this.setControlState(true, null);
                    return;
                }
            }
            string filePath = Path.Combine(directory, this.cbDatabaseName.SelectedItem.ToString() + DateTime.Now.ToString("-yyyyMMdd-HHmmss") + ".sql");
            this.saveFile(filePath, this.cbDatabaseName.SelectedItem.ToString(), this.getBucketID());
            this.setControlState(true, null);
        }

        private void saveFile(string filePath, string dbName, string s3Bucket = null)
        {
            try
            {
                MySQL c = new MySQL(dbName);
                c.backup(filePath);
                c.close();
                Logger.getLogger(this.tbLog, LOG_FILENAME).log("Wyeksportowano pomyślnie do pliku: " + filePath);
                if (s3Bucket != null)
                {
                    S3 s3Client = new S3();
                    s3Client.send(s3Bucket, filePath, dbName + ".sql");
                    Logger.getLogger(this.tbLog, LOG_FILENAME).log("Wysłano!");
                }
            }
            catch (Exception ex)
            {
                Logger.getLogger(this.tbLog, LOG_FILENAME).log("ERROR: " + ex.Message);
            }
        }

        private void setControlState(bool state, Control sender)
        {
            foreach (Control control in this.Controls)
            {
                if (control != sender && control != this.tbLog && control != this.bToggleLog)
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

        private int prevHeight;

        private void bToggleLog_Click(object sender, EventArgs e)
        {
            this.prevHeight = this.Height;
            if (bToggleLog.Text.Equals("▼"))
            {
                bToggleLog.Text = "▲";
                this.Height = this.prevHeight * 2;
                this.prevHeight = this.Height;
            }
            else
            {
                bToggleLog.Text = "▼";
                this.Height = this.prevHeight / 2;
                this.prevHeight = this.Height;
            }
        }

        private void tLogger_Tick(object sender, EventArgs e)
        {
            Logger.getLogger(this.tbLog, LOG_FILENAME).tick();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.getLogger(this.tbLog, LOG_FILENAME).cleanup();
        }
    }
}
