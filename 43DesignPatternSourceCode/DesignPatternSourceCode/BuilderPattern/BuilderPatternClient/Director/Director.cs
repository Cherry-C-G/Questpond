using System;
using System.Collections.Generic;
using System.Text;
using Report;
using Builder;
namespace Director
{
    public class clsDirector
    {
        public clsReport MakeReport(ReportBuilder objBuilder)
        {
            objBuilder.createNewReport();
            objBuilder.setReportType();
            objBuilder.setReportHeader();
            objBuilder.setReportFooter();
            return objBuilder.getReport();
        }
    }
}
