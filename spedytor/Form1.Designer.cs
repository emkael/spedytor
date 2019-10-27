namespace spedytor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lChooseDatabase = new System.Windows.Forms.Label();
            this.cSend = new System.Windows.Forms.CheckBox();
            this.nInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tInterval = new System.Windows.Forms.Timer(this.components);
            this.bTimer = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.bSettings = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bToggleLog = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tLogger = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bSelectDBs = new System.Windows.Forms.Button();
            this.lDumpStats = new System.Windows.Forms.Label();
            this.lSendStats = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nInterval)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lChooseDatabase
            // 
            this.lChooseDatabase.AutoSize = true;
            this.lChooseDatabase.Location = new System.Drawing.Point(12, 11);
            this.lChooseDatabase.Name = "lChooseDatabase";
            this.lChooseDatabase.Size = new System.Drawing.Size(71, 13);
            this.lChooseDatabase.TabIndex = 0;
            this.lChooseDatabase.Text = "Bazy danych:";
            // 
            // cSend
            // 
            this.cSend.AutoSize = true;
            this.cSend.Location = new System.Drawing.Point(244, 10);
            this.cSend.Name = "cSend";
            this.cSend.Size = new System.Drawing.Size(50, 17);
            this.cSend.TabIndex = 2;
            this.cSend.Text = "wyślij";
            this.cSend.UseVisualStyleBackColor = true;
            // 
            // nInterval
            // 
            this.nInterval.Location = new System.Drawing.Point(224, 65);
            this.nInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nInterval.Name = "nInterval";
            this.nInterval.Size = new System.Drawing.Size(70, 20);
            this.nInterval.TabIndex = 8;
            this.nInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "minut";
            // 
            // tInterval
            // 
            this.tInterval.Tick += new System.EventHandler(this.tInterval_Tick);
            // 
            // bTimer
            // 
            this.bTimer.Enabled = false;
            this.bTimer.Image = global::spedytor.Properties.Resources.refresh;
            this.bTimer.Location = new System.Drawing.Point(153, 35);
            this.bTimer.Name = "bTimer";
            this.bTimer.Size = new System.Drawing.Size(70, 70);
            this.bTimer.TabIndex = 7;
            this.bTimer.Text = "Zapisz co...";
            this.bTimer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bTimer.UseVisualStyleBackColor = true;
            this.bTimer.Click += new System.EventHandler(this.bTimer_Click);
            // 
            // bExit
            // 
            this.bExit.Image = global::spedytor.Properties.Resources.close;
            this.bExit.Location = new System.Drawing.Point(224, 105);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(70, 70);
            this.bExit.TabIndex = 6;
            this.bExit.Text = "Zakończ";
            this.bExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bSettings
            // 
            this.bSettings.Image = global::spedytor.Properties.Resources.settings;
            this.bSettings.Location = new System.Drawing.Point(153, 105);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(70, 70);
            this.bSettings.TabIndex = 5;
            this.bSettings.Text = "Opcje...";
            this.bSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // bSave
            // 
            this.bSave.Enabled = false;
            this.bSave.Image = global::spedytor.Properties.Resources.save;
            this.bSave.Location = new System.Drawing.Point(12, 35);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(140, 140);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Zapisz...";
            this.bSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bToggleLog
            // 
            this.bToggleLog.Location = new System.Drawing.Point(115, 181);
            this.bToggleLog.Name = "bToggleLog";
            this.bToggleLog.Size = new System.Drawing.Size(75, 23);
            this.bToggleLog.TabIndex = 10;
            this.bToggleLog.Text = "▼";
            this.bToggleLog.UseVisualStyleBackColor = true;
            this.bToggleLog.Click += new System.EventHandler(this.bToggleLog_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(13, 236);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(282, 203);
            this.tbLog.TabIndex = 11;
            // 
            // tLogger
            // 
            this.tLogger.Enabled = true;
            this.tLogger.Tick += new System.EventHandler(this.tLogger_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Spedytor";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(118, 22);
            this.closeMenuItem.Text = "Zakończ";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // bSelectDBs
            // 
            this.bSelectDBs.Location = new System.Drawing.Point(89, 4);
            this.bSelectDBs.Name = "bSelectDBs";
            this.bSelectDBs.Size = new System.Drawing.Size(148, 23);
            this.bSelectDBs.TabIndex = 12;
            this.bSelectDBs.Text = "[nie wybrano]";
            this.bSelectDBs.UseVisualStyleBackColor = true;
            this.bSelectDBs.Click += new System.EventHandler(this.button1_Click);
            // 
            // lDumpStats
            // 
            this.lDumpStats.AutoSize = true;
            this.lDumpStats.Location = new System.Drawing.Point(12, 207);
            this.lDumpStats.Name = "lDumpStats";
            this.lDumpStats.Size = new System.Drawing.Size(68, 13);
            this.lDumpStats.TabIndex = 13;
            this.lDumpStats.Text = "Ostatni zrzut:";
            // 
            // lSendStats
            // 
            this.lSendStats.AutoSize = true;
            this.lSendStats.Location = new System.Drawing.Point(12, 220);
            this.lSendStats.Name = "lSendStats";
            this.lSendStats.Size = new System.Drawing.Size(91, 13);
            this.lSendStats.TabIndex = 14;
            this.lSendStats.Text = "Ostatnia wysyłka:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 208);
            this.Controls.Add(this.lSendStats);
            this.Controls.Add(this.lDumpStats);
            this.Controls.Add(this.bSelectDBs);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.bToggleLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nInterval);
            this.Controls.Add(this.bTimer);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bSettings);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.cSend);
            this.Controls.Add(this.lChooseDatabase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Spedytor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nInterval)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lChooseDatabase;
        private System.Windows.Forms.CheckBox cSend;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bTimer;
        private System.Windows.Forms.NumericUpDown nInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tInterval;
        private System.Windows.Forms.Button bToggleLog;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Timer tLogger;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.Button bSelectDBs;
        private System.Windows.Forms.Label lDumpStats;
        private System.Windows.Forms.Label lSendStats;
    }
}

