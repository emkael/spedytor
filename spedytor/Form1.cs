using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;

namespace spedytor
{
    public partial class Form1 : Form
    {
        const string LOG_FILENAME = "spedytor.log";
        private List<string> selectedDBs = new List<string>();
        private dbWindow dbSelectionWindow = new dbWindow();
        private int runningDumps = 0;

        public Form1()
        {
            InitializeComponent();
            this.dbSelectionWindow.setParent(this);
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            if (this.selectedDBs.Count > 0)
            {
                if (MessageBox.Show("Czy chcesz zrzucić/wysłać bazy przed zakończeniem działania programu?", "Spedytor - wyjście", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tInterval_Tick(null, null);
                }
            }
            this.tLogger.Enabled = false;
            Logger.getLogger(this.tbLog, LOG_FILENAME).cleanup();
            this.saveSettings();
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!MySQL.getConfigured()) (new MysqlSettings()).ShowDialog();
            if (!MySQL.getConfigured()) this.Dispose();
            this.restoreSettings();
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
            this.dbSelectionWindow.lbDatabases.Items.Clear();
            MySQL c = new MySQL("");
            MySqlDataReader dbs = c.select("SELECT TABLE_SCHEMA FROM information_schema.COLUMNS GROUP BY TABLE_SCHEMA;");
            int index = 0;
            List<string> dbNames = new List<string>();
            while (dbs.Read())
            {
                string dbName = dbs.GetString(0);
                dbNames.Add(dbName);
                this.dbSelectionWindow.lbDatabases.Items.Add(dbName);
                if (this.selectedDBs.IndexOf(dbName) > -1)
                {
                    this.dbSelectionWindow.lbDatabases.SelectedIndices.Add(index);
                }
                index++;
            }
            dbs.Close();
            this.setSelectedDBs(this.selectedDBs.Intersect(dbNames).ToList());
        }

        private string getBucketID()
        {
            if (this.cSend.Checked && spedytor.Properties.S3Settings.Default.AWS_BUCKET_ID.Length > 0)
            {
                return spedytor.Properties.S3Settings.Default.AWS_BUCKET_ID;
            }
            return null;
        }

        private Thread invokeSave(string filePath, string dbName, bool enableControls = false)
        {
            Thread t = new Thread(() => this.saveFile(filePath, dbName, this.getBucketID(), enableControls));
            t.IsBackground = true;
            t.Start();
            return t;
        }

        private string getDirectory()
        {
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
            }
            return directory;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string directory = this.getDirectory();
            if (directory.Length > 0)
            {
                foreach (string dbName in this.selectedDBs)
                {
                    string filePath = Path.Combine(directory, dbName + DateTime.Now.ToString("-yyyyMMdd-HHmmss") + ".sql");
                    this.invokeSave(filePath, dbName, true);
                }
            }
        }

        private void saveFile(string filePath, string dbName, string s3Bucket = null, bool enableControls = false)
        {
            if (enableControls && this.runningDumps == 0)
            {
                this.Invoke(new setStateDelegate(setControlState), new object[] { false, null });
            }
            this.runningDumps++;
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
                    Logger.getLogger(this.tbLog, LOG_FILENAME).log("Wysłano bazę danych: " + dbName + "!");
                }
            }
            catch (Exception ex)
            {
                Logger.getLogger(this.tbLog, LOG_FILENAME).log("ERROR: " + ex.Message);
            }
            finally
            {
                this.runningDumps--;
                if (enableControls && this.runningDumps == 0)
                {
                    this.Invoke(new setStateDelegate(setControlState), new object[] { true, null });
                }
            }
        }

        private delegate void setStateDelegate(bool state, Control sender);

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
                tInterval_Tick(this.bTimer, null);
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
                this.repeatFilePath = this.getDirectory();
            }
            if (this.repeatFilePath.Length > 0)
            {
                List<Thread> threadList = new List<Thread>();
                foreach (string dbName in this.selectedDBs)
                {
                    string filePath = Path.Combine(this.repeatFilePath, dbName + DateTime.Now.ToString("-yyyyMMdd-HHmmss") + ".sql");
                    threadList.Add(this.invokeSave(filePath, dbName, false));
                }
                if (sender == null) // programmatic invoke, not actual button click
                {
                    foreach (Thread t in threadList)
                    {
                        t.Join();
                    }
                }
            }
            else
            {
                bTimer_Click(null, null);
                return;
            }
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon.Visible = false;
        }

        private void minimizeToTray()
        {
            this.Hide();
            this.notifyIcon.Visible = true;
            this.notifyIcon.ShowBalloonTip(1000, "Spedytor", "Spedytor będzie działać w tle", ToolTipIcon.Info);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.minimizeToTray();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (this.tInterval.Enabled)
            {
                DialogResult dr = MessageBox.Show("Spedytor jest w trybie pracy ciągłej.\nCzy chcesz zakończyć działanie programu?", "Spedytor - wyjście", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        this.bExit_Click(null, null);
                        break;
                    case DialogResult.No:
                        this.minimizeToTray();
                        break;
                }
            }
            else
            {
                this.bExit_Click(null, null);
            }
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            this.bExit_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.refreshDatabaseList();
            this.dbSelectionWindow.ShowDialog();
        }

        internal void setSelectedDBs(List<string> selected)
        {
            this.selectedDBs = selected;
            this.bSave.Enabled = this.bTimer.Enabled = (this.selectedDBs.Count > 0);
            if (this.selectedDBs.Count == 0)
            {
                this.bSelectDBs.Text = "[nie wybrano]";
            }
            else
            {
                this.bSelectDBs.Text = String.Format("[wybrano: {0}]", this.selectedDBs.Count);
            }
        }

        private void restoreSettings()
        {
            this.setSelectedDBs(Properties.OptionSettings.Default.dbNames.Cast<string>().ToList());
            this.cSend.Checked = Properties.OptionSettings.Default.send;
        }

        private void saveSettings()
        {
            Properties.OptionSettings.Default.send = this.cSend.Checked;
            if (Properties.OptionSettings.Default.dbNames == null)
            {
                Properties.OptionSettings.Default.dbNames = new System.Collections.Specialized.StringCollection();
            }
            Properties.OptionSettings.Default.dbNames.Clear();
            Properties.OptionSettings.Default.dbNames.AddRange(this.selectedDBs.ToArray());
            Properties.OptionSettings.Default.Save();
        }

    }
}
