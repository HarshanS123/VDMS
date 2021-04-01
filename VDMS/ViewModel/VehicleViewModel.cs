using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VDMS.Models;

namespace VDMS.ViewModel
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Vehicle Number")]
        public string VehicleNo { get; set; }


        [Display(Name = "Vehicle Type")]
        public int TypeId { get; set; }

        [Display(Name = "Vehicle Engine No")]
        public string EngineNo { get; set; }

        [Display(Name = "Vehicle Chassi No")]
        public string ChassiNo { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Seating Capacity")]
        public int SeatingCapacity { get; set; }

        [Display(Name = "Data Of First Registration")]
        public DateTime DataOfFirstReg { get; set; }

        [Display(Name = "Cylinder Capacity")]
        public int CylinderCapacity { get; set; }

        [Display(Name = "Manufactured Year")]
        public int ManufacturedYear { get; set; }
        public int ManufactureId { get; set; }

        [Display(Name = "Owner")]
        public int OwnerId { get; set; }       

        public IEnumerable<OwenrViewModel> Owners { get; set; }
        public IEnumerable<ManufactureViewModel> Manufactures { get; set; }
        public virtual IEnumerable<VTypeViewModel> VTypes { get; set; }

        
    }
}