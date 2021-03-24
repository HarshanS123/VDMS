using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using VDMS.Models;

namespace VDMS.DataRepository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverVehicleRecord> DriverVehicleRecords { get; set; }
        public DbSet<FuelRecord> FuelRecords { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<ServiceCenter> ServiceCenters { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleAssignedRecord> VehicleAssignedRecords { get; set; }
        public DbSet<VType> VTypes { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
    }
}