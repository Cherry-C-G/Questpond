using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternArchitecturePattern
{
    public interface IExport
    {
        void Export();
    }
    public class WordExport : IExport
    {
        public void Export()
        {
            throw new NotImplementedException();
        }
    }
    public class ExcelExport : IExport
    {
        public void Export()
        {
            throw new NotImplementedException();
        }
    }
    public class PdfAdapter : PdfExport, IExport 
    {
        public void Export()
        {
            this.Save();
        }
    }
    public class PdfExport
    {
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
