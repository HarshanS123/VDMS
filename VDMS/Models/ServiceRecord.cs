using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class ServiceRecord
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string ServiceNo { get; set; }

        public DateTime Date { get; set; }
        public double Cost { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        public int Milage { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int ServiceCenterId { get; set; }
        public ServiceCenter ServiceCenter { get; set; }
    }
}