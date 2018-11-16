using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace spedytor
{
    public partial class MysqlSettings : Form
    {
        public MysqlSettings()
        {
            InitializeComponent();
        }

        private void MysqlSettings_Load(object sender, EventArgs e)
        {
            eHost.Text = Properties.Settings.Default.HOST;
            eUser.Text = Properties.Settings.Default.USER;
            ePass.Text = Properties.Settings.Default.PASS;
            ePort.Text = Properties.Settings.Default.PORT;
            eS3ID.Text = Properties.S3Settings.Default.AWS_ACCESS_KEY;
            eS3Key.Text = Properties.S3Settings.Default.AWS_SECRET_KEY;
            eS3Bucket.Text = Properties.S3Settings.Default.AWS_BUCKET_ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HOST = eHost.Text.Trim();
            Properties.Settings.Default.USER = eUser.Text.Trim();
            Properties.Settings.Default.PASS = ePass.Text;
            Properties.Settings.Default.PORT = ePort.Text;
            Properties.S3Settings.Default.AWS_ACCESS_KEY = eS3ID.Text.Trim();
            Properties.S3Settings.Default.AWS_SECRET_KEY = eS3Key.Text.Trim();
            Properties.S3Settings.Default.AWS_BUCKET_ID = eS3Bucket.Text.Trim();
            Properties.S3Settings.Default.Save();

            string msg = MySQL.test();
            if (msg == "")
            {
                Properties.Settings.Default.CONFIGURED = true;
                Properties.Settings.Default.Save();
                Close();
            }
            else
            {
                MessageBox.Show(msg, "Nieprawidłowe ustawienia MySQL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
