using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;

namespace VDMS.ViewModel
{
    public class DriverViewModel
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string NIC { get; set; }
        public int AppointmentId { get; set; }
        public AppointmentViewModel Appointment { get; set; }
        public bool Status { get; set; }

        public IEnumerable<AppointmentViewModel> Appointments { get; set; }
        public IEnumerable<DriverVehicleRecordViewModel> DriverVehicleRecords { get; set; }
    }
}