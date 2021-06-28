using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;

namespace VDMS.ViewModel
{
    public class ReceiverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public IEnumerable<VehicleAssignedRecord> VehicleAssignedRecords { get; set; }
    }
}