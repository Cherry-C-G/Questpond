using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace WindowsMediator
{
    class clsMediator
    {
        private TextBox objTextBox;
        private ListBox objListBox;
        private Button btnClear;
        private Button btnAdd;
        public void Register(TextBox obj)
        {
            objTextBox = obj;
        }
        public void Register(ListBox obj)
        {
            objListBox = obj;
        }
        public void Register(Button obj)
        {
            if (obj.Name == "btnAdd")
            {
                btnAdd = obj;
            }
            else
            {
                btnClear = obj;
                
            }
            obj.Enabled = false;
        }
        public void TextChange()
        {
            if (objTextBox.Text.Length > 0)
            {
                btnClear.Enabled = true;
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnClear.Enabled = false;
            }
        }
        public void ClickAddButton()
        {
            objListBox.Items.Add(objTextBox.Text);
            btnClear.Enabled = false;
            btnAdd.Enabled = false;
            objTextBox.Text = "";
        }
        public void ClickClearButton()
        {
            objTextBox.Text = "";
            btnAdd.Enabled = false;
            btnClear.Enabled = false;
        }
        
    }
}
