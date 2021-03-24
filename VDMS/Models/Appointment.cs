using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string AppointmentName { get; set; }

        public ICollection<Driver> Drivers { get; set; }

    }
}