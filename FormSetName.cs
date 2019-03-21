using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoomRPG
{
    public partial class FormSetName : Form
    {
        public string Result;
        IEnumerable<string> Names;

        public FormSetName(string text, IEnumerable<string> names)
        {
            InitializeComponent();
            textBoxName.Text = text;
            Names = names;
        }

        private void FormSetName_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (Result == "")
                {
                    MessageBox.Show("Name can't be empty");
                    e.Cancel = true;
                }
                else if (Names.Contains(Result))
                {
                    MessageBox.Show("This name is already in use");
                    e.Cancel = true;
                }
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Result = textBoxName.Text;
        }
    }
}
