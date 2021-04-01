using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class InsuranceClaim
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public string PaymentStatus { get; set; }
        public bool Status { get; set; }
        public int InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
    }
}