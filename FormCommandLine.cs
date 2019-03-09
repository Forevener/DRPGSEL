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
    public partial class FormCommandLine : Form
    {
        public FormCommandLine(string commandLine)
        {
            InitializeComponent();
            textBoxCommandLine.Text = commandLine;
            // Prevent selection of TextBox's entire content
            textBoxCommandLine.Select(commandLine.Length, 0);
        }
    }
}
