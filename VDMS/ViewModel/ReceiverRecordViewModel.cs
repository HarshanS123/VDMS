using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;

namespace VDMS.ViewModel
{
    public class ReceiverRecordViewModel
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public int VehicleId { get; set; }
        public Receiver Receiver { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime AssingData { get; set; }
        public DateTime? TerminateDate { get; set; }
        public bool Status { get; set; }

        public IEnumerable<VehicleViewModel> Vehicles { get; set; }
        public IEnumerable<ReceiverViewModel> Receivers { get; set; }
    }
}