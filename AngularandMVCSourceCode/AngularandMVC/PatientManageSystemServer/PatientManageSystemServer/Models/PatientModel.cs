using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManageSystemServer.Models
{
    public class Patient 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public List<Problem> problems { get; set; }
    }
    public class Problem
    {
        public int id { get; set; }
        public string description { get; set; }
    }
}
