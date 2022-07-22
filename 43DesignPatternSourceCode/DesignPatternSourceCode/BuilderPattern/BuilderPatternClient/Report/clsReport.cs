using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Report
{
    public class clsReport
    {
        public string strReportType;
        private ArrayList objHeader = new ArrayList();
        private ArrayList objFooter = new ArrayList();
        public void setReportFooter(string strData)
        {
            objFooter.Add(strData);
        }
        public void setReportHeader(string strData)
        {
            objHeader.Add(strData);
        }
        public void displayReport()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Report is of type " + strReportType);
            foreach (string str in objHeader)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("------");
            foreach (string str in objFooter)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("----------------------");
        }
    }
}
