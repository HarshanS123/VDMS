using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.ViewModel
{
    public class OwenrViewModel
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public virtual ICollection<VehicleViewModel> Vehicles { get; set; }
    }
}