using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
    }
}
