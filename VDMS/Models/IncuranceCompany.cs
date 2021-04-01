using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class IncuranceCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Insurance> Insurances { get; set; }
    }
}