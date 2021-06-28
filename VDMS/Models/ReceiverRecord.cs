using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class ReceiverRecord
    {
        public int Id { get; set; }
        public DateTime AssingData { get; set; }
        public DateTime? TerminateDate { get; set; }
        public int ReceiverId { get; set; }
        public int VehicleId { get; set; }
        public Receiver Receiver { get; set; }
        public Vehicle Vehicle { get; set; }
        public bool Status { get; set; }

    }
}