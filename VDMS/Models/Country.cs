using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class Country
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Manufacture> Manufactures { get; set; }
    }
}