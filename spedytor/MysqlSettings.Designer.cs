namespace spedytor
{
    partial class MysqlSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MysqlSettings));
            this.eHost = new System.Windows.Forms.TextBox();
            this.eUser = new System.Windows.Forms.TextBox();
            this.ePass = new System.Windows.Forms.TextBox();
            this.ePort = new System.Windows.Forms.TextBox();
            this.bOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.eS3ID = new System.Windows.Forms.TextBox();
            this.eS3Key = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // eHost
            // 
            this.eHost.Location = new System.Drawing.Point(49, 19);
            this.eHost.Name = "eHost";
            this.eHost.Size = new System.Drawing.Size(100, 20);
            this.eHost.TabIndex = 0;
            // 
            // eUser
            // 
            this.eUser.Location = new System.Drawing.Point(49, 45);
            this.eUser.Name = "eUser";
            this.eUser.Size = new System.Drawing.Size(100, 20);
            this.eUser.TabIndex = 1;
            // 
            // ePass
            // 
            this.ePass.Location = new System.Drawing.Point(49, 71);
            this.ePass.Name = "ePass";
            this.ePass.PasswordChar = '*';
            this.ePass.Size = new System.Drawing.Size(100, 20);
            this.ePass.TabIndex = 2;
            // 
            // ePort
            // 
            this.ePort.Location = new System.Drawing.Point(49, 97);
            this.ePort.Name = "ePort";
            this.ePort.Size = new System.Drawing.Size(100, 20);
            this.ePort.TabIndex = 3;
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(12, 227);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(155, 23);
            this.bOk.TabIndex = 4;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.eHost);
            this.groupBox1.Controls.Add(this.eUser);
            this.groupBox1.Controls.Add(this.ePort);
            this.groupBox1.Controls.Add(this.ePass);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 126);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MySQL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Host:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "User:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hasło:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.eS3ID);
            this.groupBox2.Controls.Add(this.eS3Key);
            this.groupBox2.Location = new System.Drawing.Point(12, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 77);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "S3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Klucz:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "ID:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // eS3ID
            // 
            this.eS3ID.Location = new System.Drawing.Point(49, 19);
            this.eS3ID.Name = "eS3ID";
            this.eS3ID.Size = new System.Drawing.Size(100, 20);
            this.eS3ID.TabIndex = 0;
            // 
            // eS3Key
            // 
            this.eS3Key.Location = new System.Drawing.Point(49, 45);
            this.eS3Key.Name = "eS3Key";
            this.eS3Key.Size = new System.Drawing.Size(100, 20);
            this.eS3Key.TabIndex = 1;
            // 
            // MysqlSettings
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 260);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MysqlSettings";
            this.Text = "Ustawienia";
            this.Load += new System.EventHandler(this.MysqlSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox eHost;
        private System.Windows.Forms.TextBox eUser;
        private System.Windows.Forms.TextBox ePass;
        private System.Windows.Forms.TextBox ePort;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox eS3ID;
        private System.Windows.Forms.TextBox eS3Key;
    }
}