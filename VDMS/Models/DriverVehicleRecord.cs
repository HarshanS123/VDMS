using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class DriverVehicleRecord
    {
        public int Id { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime? TerminateDate { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Driver Driver { get; set; }
    }
}