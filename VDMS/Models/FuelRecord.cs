using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class FuelRecord
    {
        public int Id { get; set; }
        public string CouponNo { get; set; }
        public DateTime Date  { get; set; }    
      
        public int CurrentMeterReading { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public int VehicleId { get; set; }
        public bool Status { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}