namespace kurier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lChooseDatabase = new System.Windows.Forms.Label();
            this.cbDatabaseName = new System.Windows.Forms.ComboBox();
            this.cSend = new System.Windows.Forms.CheckBox();
            this.tBucketID = new System.Windows.Forms.TextBox();
            this.bExit = new System.Windows.Forms.Button();
            this.bSettings = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lChooseDatabase
            // 
            this.lChooseDatabase.AutoSize = true;
            this.lChooseDatabase.Location = new System.Drawing.Point(9, 13);
            this.lChooseDatabase.Name = "lChooseDatabase";
            this.lChooseDatabase.Size = new System.Drawing.Size(74, 13);
            this.lChooseDatabase.TabIndex = 0;
            this.lChooseDatabase.Text = "Wybierz bazę:";
            // 
            // cbDatabaseName
            // 
            this.cbDatabaseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabaseName.FormattingEnabled = true;
            this.cbDatabaseName.Location = new System.Drawing.Point(89, 10);
            this.cbDatabaseName.Name = "cbDatabaseName";
            this.cbDatabaseName.Size = new System.Drawing.Size(138, 21);
            this.cbDatabaseName.TabIndex = 1;
            // 
            // cSend
            // 
            this.cSend.AutoSize = true;
            this.cSend.Location = new System.Drawing.Point(12, 37);
            this.cSend.Name = "cSend";
            this.cSend.Size = new System.Drawing.Size(83, 17);
            this.cSend.TabIndex = 2;
            this.cSend.Text = "ślij Zimnemu";
            this.cSend.UseVisualStyleBackColor = true;
            this.cSend.CheckedChanged += new System.EventHandler(this.cSend_CheckedChanged);
            // 
            // tBucketID
            // 
            this.tBucketID.Enabled = false;
            this.tBucketID.Location = new System.Drawing.Point(89, 35);
            this.tBucketID.Name = "tBucketID";
            this.tBucketID.Size = new System.Drawing.Size(138, 20);
            this.tBucketID.TabIndex = 3;
            // 
            // bExit
            // 
            this.bExit.Image = global::kurier.Properties.Resources.close;
            this.bExit.Location = new System.Drawing.Point(152, 133);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(70, 70);
            this.bExit.TabIndex = 6;
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bSettings
            // 
            this.bSettings.Image = global::kurier.Properties.Resources.settings;
            this.bSettings.Location = new System.Drawing.Point(152, 63);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(70, 70);
            this.bSettings.TabIndex = 5;
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // bSave
            // 
            this.bSave.Image = global::kurier.Properties.Resources.save;
            this.bSave.Location = new System.Drawing.Point(12, 63);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(140, 140);
            this.bSave.TabIndex = 4;
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 212);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bSettings);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tBucketID);
            this.Controls.Add(this.cSend);
            this.Controls.Add(this.cbDatabaseName);
            this.Controls.Add(this.lChooseDatabase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "KurierSQL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lChooseDatabase;
        private System.Windows.Forms.ComboBox cbDatabaseName;
        private System.Windows.Forms.CheckBox cSend;
        private System.Windows.Forms.TextBox tBucketID;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.Button bExit;
    }
}

