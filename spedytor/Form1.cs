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
            this.Dispose();
        }

        private void cSend_CheckedChanged(object sender, EventArgs e)
        {
            this.tBucketID.Enabled = this.cSend.Checked;
            if (this.cSend.Checked)
            {
                this.tBucketID.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!MySQL.getConfigured()) (new MysqlSettings()).ShowDialog();
            if (!MySQL.getConfigured()) this.Dispose();
            this.refreshDatabaseList();
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            (new MysqlSettings()).ShowDialog();
            this.refreshDatabaseList();
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

        private void bSave_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string filePath = Path.Combine(fd.SelectedPath, this.cbDatabaseName.SelectedItem.ToString() + DateTime.Now.ToString("-yyyyMMdd-HHmmss") + ".sql");
                try
                {
                    MySQL c = new MySQL(this.cbDatabaseName.SelectedItem.ToString());
                    c.backup(filePath);
                    c.close();
                    MessageBox.Show("Wyeksportowano pomyślnie do pliku: " + filePath, "Sukces eksportu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (cSend.Checked) {
                        if (tBucketID.Text.Length > 0)
                        {
                            S3 s3Client = new S3();
                            s3Client.send(this.tBucketID.Text, filePath, this.cbDatabaseName.SelectedItem.ToString() + ".sql");
                            MessageBox.Show("Wysłano Zimnemu!", "Sukces eksportu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nie wpisałeś ID do wysłania Zimnemu!", "Błąd eksportu!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Błąd eksportu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void tBucketID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                this.bSave_Click(null, null);
            }
        }
    }
}
