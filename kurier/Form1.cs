using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace kurier
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Błąd eksportu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
