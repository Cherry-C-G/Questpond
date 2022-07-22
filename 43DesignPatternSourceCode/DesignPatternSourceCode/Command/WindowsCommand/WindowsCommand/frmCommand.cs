using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsCommand
{
    public partial class frmCommand : Form
    {
        public frmCommand()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkAction("File");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkAction("Open");
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkAction("Print");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkAction("Exit");
        }
        private void checkAction(string strAction)
        {
            clsInvoker objInvoker = new clsInvoker();
            IExecute iobjExecute= objInvoker.getCommand(strAction);
            iobjExecute.execute();
           
        }
        private void frmCommand_Load(object sender, EventArgs e)
        {

        }
    }
}