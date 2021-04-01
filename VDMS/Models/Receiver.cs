using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class Receiver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public ICollection<VehicleAssignedRecord> VehicleAssignedRecords { get; set; }
    }
}