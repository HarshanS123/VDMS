using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;

namespace VDMS.ViewModel
{
    public class ManufactureViewModel
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public IEnumerable<CountryViewModel> Countries { get; set; }
        
    }
}