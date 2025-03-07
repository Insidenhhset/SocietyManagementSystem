using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyManagementSystem
{
    [Serializable]
    public class Report
    {
        // ----- Bill Report Properties -----
        public string BillTitle { get; set; }
        public string FlatNo { get; set; }
        public string BillAmount { get; set; }
        public string BillMonth { get; set; }
        public string PaidDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaidAmount { get; set; }
        public string status { get; set; }

        // ----- Complaint Report Properties -----
        public string UserName { get; set; }
        public string ComplaintMessage { get; set; }
        public string ComplaintStatus { get; set; }
        public string ComplaintCreatedAt { get; set; }

        // ----- Visitor Report Properties -----
        public string VisitorName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PersonToMeet { get; set; }
        public string Reason { get; set; }
        public string InDate { get; set; }
        public string OutRemark { get; set; }
        public string OutDate { get; set; }
        public string VisitorStatus { get; set; }
    }

}