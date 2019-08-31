namespace spedytor
{
    partial class dbWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbWindow));
            this.bOK = new System.Windows.Forms.Button();
            this.lbDatabases = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(13, 220);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(259, 23);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // lbDatabases
            // 
            this.lbDatabases.FormattingEnabled = true;
            this.lbDatabases.Location = new System.Drawing.Point(13, 13);
            this.lbDatabases.Name = "lbDatabases";
            this.lbDatabases.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbDatabases.Size = new System.Drawing.Size(259, 199);
            this.lbDatabases.TabIndex = 3;
            // 
            // dbWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 255);
            this.Controls.Add(this.lbDatabases);
            this.Controls.Add(this.bOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dbWindow";
            this.Text = "Wybór baz danych";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOK;
        public System.Windows.Forms.ListBox lbDatabases;
    }
}