using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class BookingDetailTemp
    {
        public int BookingID { get; set; }
        public string BookingNo { get; set; }
        public string BookingDate { get; set; }
        public string Createdby { get; set; }
        public string CreatedDate { get; set; }
        public string BookingApproval { get; set; }
        public string BookingApprovalDate { get; set; }
    }
}