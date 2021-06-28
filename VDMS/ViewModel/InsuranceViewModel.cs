using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;

namespace VDMS.ViewModel
{
    public class InsuranceViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PolicyNo { get; set; }
        public int VehicleId { get; set; }
        public bool Status { get; set; }
        public Vehicle Vehicle { get; set; }
        public int IncuranceCompanyId { get; set; }
        public IncuranceCompany IncuranceCompany { get; set; }
        public IEnumerable<VehicleViewModel> Vehicles { get; set; }
        public IEnumerable<InsuranceClaim> InsuranceClaims { get; set; }

        public IEnumerable<IncuranceCompanyViewModel> IncuranceCompanies { get; set; }
    }
}