using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PolicyNo { get; set; }
        public int VehicleId { get; set; }
        public bool Status { get; set; }
        public Vehicle Vehicle { get; set; }
        public IncuranceCompany IncuranceCompanyId { get; set; }
        public IncuranceCompany IncuranceCompany { get; set;}

        public ICollection<InsuranceClaim> InsuranceClaims { get; set; }
    }
}