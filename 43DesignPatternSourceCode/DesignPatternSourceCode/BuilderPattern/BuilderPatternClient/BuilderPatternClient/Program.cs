using System;
using System.Collections.Generic;
using System.Text;
using Report;
using Builder;
using Director;
namespace BuilderPatternClient
{
    class Program
    {
        static void Main(string[] args)
        {
            clsReport objReport;
            clsDirector objDirector = new clsDirector();
            
            ReportPDF objRptPdf = new ReportPDF();
            objReport = objDirector.MakeReport(objRptPdf);
            objReport.displayReport();
            
            ReportExcel objRptExcel = new ReportExcel();
            objReport = objDirector.MakeReport(objRptExcel);
            objReport.displayReport();
            
            Console.ReadLine();


        }
    }
}
