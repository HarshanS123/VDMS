using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;

namespace VDMS.ViewModel
{
    public class DriverVehicleRecordViewModel
    {
        public int Id { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime? TerminateDate { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Driver Driver { get; set; }

        public IEnumerable<VehicleViewModel> vehicleViewModels { get; set; }
        public IEnumerable<DriverViewModel> driverViewModels { get; set; }

    }
}