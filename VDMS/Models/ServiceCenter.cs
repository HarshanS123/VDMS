using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class ServiceCenter
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<ServiceRecord> ServiceRecords { get; set; }
    }
}