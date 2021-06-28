using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.ViewModel
{
    public class ServiceCenterViewModel
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public ICollection<ServiceRecordViewModel> ServiceRecords { get; set; }
    }
}