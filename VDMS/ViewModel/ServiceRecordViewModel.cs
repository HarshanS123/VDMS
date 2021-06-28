using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;

namespace VDMS.ViewModel
{
    public class ServiceRecordViewModel
    {
        public int Id { get; set; }
     
        public string ServiceNo { get; set; }

        public DateTime Date { get; set; }
        public double Cost { get; set; }
      
        public string Description { get; set; }
        public int Milage { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public bool Status { get; set; }
        public int ServiceCenterId { get; set; }
        public ServiceCenter ServiceCenter { get; set; }

        public IEnumerable<VehicleViewModel> vehicles { get; set; }
        public IEnumerable<ServiceCenterViewModel> ServiceCenters { get; set; }
    }
}