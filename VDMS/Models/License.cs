using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class License
    {
        public int Id { get; set; }

        public DateTime Renewal { get; set; }

        public DateTime Expiry { get; set; }

        public string DsOffice { get; set; }

        public int VehicleId { get; set; }

        public double Amount { get; set; }

        public Vehicle vehicle { get; set; }
    }
}