using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class VType
    {
        public int Id { get; set; }
        [StringLength(15)]
        public string Name { get; set; }
       
    }
}