using System;
using System.Collections.Generic;
using System.Text;
using Report;
namespace Builder
{
    public abstract  class ReportBuilder
    {
        protected clsReport objReport;
        public abstract void setReportType();
        public abstract void setReportHeader();
        public abstract void setReportFooter();
        public void createNewReport()
        {
            objReport = new clsReport();
        }
        public clsReport getReport()
        {
            return objReport;
        }
    }
    public class ReportPDF : ReportBuilder
    {
        public override void setReportType()
        {
            objReport.strReportType = "PDF";
        }
        public override void setReportHeader()
        {
            objReport.setReportHeader(" XYZ PVT LTD PDF report");
        }
        public override void setReportFooter()
        {
            objReport.setReportFooter("End of PDF report");
        }
    }
    public class ReportExcel : ReportBuilder
    {
        public override void setReportType()
        {
            objReport.strReportType = "EXCEL";
        }
        public override void setReportHeader()
        {
            objReport.setReportHeader(" XYZ PVT LTD EXCEL report");
        }
        public override void setReportFooter()
        {
            objReport.setReportFooter("End of EXCEL report");
        }
    }
    }
   
