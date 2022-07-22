using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace WindowsInterpreterClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            ArrayList obj = new ArrayList();
            clsContext objContext = new clsContext(txtDateFormat.Text.Trim());
            string[] strArray = objContext.strExpression.Split(' ');
            
            foreach (string strTemp in strArray)
            {
                if (strTemp == "MM")
                {
                    obj.Add(new clsMonthExpression());
                }
                else if (strTemp == "DD")
                {
                    obj.Add(new clsDayExpression());
                }
                else if (strTemp == "YYYY")
                {
                    obj.Add(new clsYearExpression());
                }
            }
            
            obj.Add(new clsSeperator());

            foreach (clsAbstractExpression objAbstract in obj)
            {
                objAbstract.Evaluate(objContext);
            }
            MessageBox.Show(objContext.strExpression);
        }
    }
}