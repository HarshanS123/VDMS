using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.ViewModel
{
    public class VTypeViewModel
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public IEnumerable<VehicleViewModel> Vehicles { get; set; }
    }
}