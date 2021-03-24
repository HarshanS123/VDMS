using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class Driver
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(15)]
        public string NIC { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public ICollection<DriverVehicleRecord> DriverVehicleRecords { get; set; }
    }
}