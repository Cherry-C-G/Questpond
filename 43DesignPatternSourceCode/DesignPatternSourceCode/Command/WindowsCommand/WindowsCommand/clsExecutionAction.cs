using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
namespace WindowsCommand
{
    class clsExecuteFile : IExecute
    {
        public clsExecuteFile()
        {
            strCommand = "File";
        }
        public override void execute()
        {
            MessageBox.Show("File command");
        }
    }
    class clsExecuteExit : IExecute
    {
        
        public clsExecuteExit()
        {
            strCommand = "Exit";
        }
        public override void execute()
        {
            MessageBox.Show("Exit command");
        }
    }
    class clsExecuteOpen : IExecute
    {
        
        public clsExecuteOpen()
        {
            strCommand = "Open";
        }
        public override void execute()
        {
            MessageBox.Show("Open command");
        }
    }
    class clsExecutePrint : IExecute
    {
        
        public clsExecutePrint()
        {
            strCommand = "Print";
        }
        public override void execute()
        {
            MessageBox.Show("Print command");
        }
    }
    class clsInvoker
    {
        private ArrayList objArrayList = new ArrayList(); 
        public clsInvoker()
        {
            objArrayList.Add(new clsExecuteExit());
            objArrayList.Add(new clsExecuteFile());
            objArrayList.Add(new clsExecuteOpen());
            objArrayList.Add(new clsExecutePrint());
        }
        public IExecute getCommand(string strCommand)
        {
            foreach (object obj in objArrayList)
            {
                IExecute objExecute = (IExecute)obj;
                if (objExecute.strCommand == strCommand)
                {
                    return objExecute;
                }
            }
            return null;
        }
    }
}
