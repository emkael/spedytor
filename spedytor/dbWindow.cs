using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace spedytor
{
    public partial class dbWindow : Form
    {
        private Form1 mainForm;

        public dbWindow()
        {
            InitializeComponent();
        }

        public void setParent(Form1 parent)
        {
            this.mainForm = parent;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (this.mainForm != null)
            {
                List<string> selected = new List<string>();
                foreach (int index in this.lbDatabases.SelectedIndices)
                {
                    selected.Add(this.lbDatabases.Items[index].ToString());
                }
                this.mainForm.setSelectedDBs(selected);
            }
            this.Close();
        }

    }
}
