using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class Manufacture
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}