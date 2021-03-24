using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDMS.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [StringLength(15)]
        public string VehicleNo { get; set; }
        public int TypeId { get; set; }
        [StringLength(100)]
        public string EngineNo { get; set; }
        [StringLength(100)]
        public string ChassiNo { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        
        public int SeatingCapacity { get; set; }
        public DateTime DataOfFirstReg { get; set; }
        
        public int CylinderCapacity { get; set; }
        
        public int ManufacturedYear { get; set; }
        public int ManufactureId { get; set; }        
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public Manufacture Manufacture { get; set; }
        public VType Type { get; set; }

        public ICollection<ServiceRecord> serviceRecords { get; set; }
        public  ICollection<FuelRecord> FuelRecords { get; set; }
        public  ICollection<DriverVehicleRecord> DriverVehicleRecords { get; set; }

        public  ICollection<VehicleAssignedRecord> VehicleAssignedRecords { get; set; }
        
    }
}