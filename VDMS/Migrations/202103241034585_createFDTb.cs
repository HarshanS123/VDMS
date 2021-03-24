namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createFDTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverVehicleRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignDate = c.DateTime(nullable: false),
                        TerminateDate = c.DateTime(),
                        VehicleId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.FuelRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CouponNo = c.String(),
                        Date = c.DateTime(nullable: false),
                        PreviousMeterReading = c.Int(nullable: false),
                        CurrentMeterReading = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.ServiceRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceNo = c.String(maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        Cost = c.Double(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Milage = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        ServiceCenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceCenters", t => t.ServiceCenterId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.ServiceCenterId);
            
            CreateTable(
                "dbo.ServiceCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRecords", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.ServiceRecords", "ServiceCenterId", "dbo.ServiceCenters");
            DropForeignKey("dbo.FuelRecords", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.DriverVehicleRecords", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.DriverVehicleRecords", "DriverId", "dbo.Drivers");
            DropIndex("dbo.ServiceRecords", new[] { "ServiceCenterId" });
            DropIndex("dbo.ServiceRecords", new[] { "VehicleId" });
            DropIndex("dbo.FuelRecords", new[] { "VehicleId" });
            DropIndex("dbo.DriverVehicleRecords", new[] { "DriverId" });
            DropIndex("dbo.DriverVehicleRecords", new[] { "VehicleId" });
            DropTable("dbo.ServiceCenters");
            DropTable("dbo.ServiceRecords");
            DropTable("dbo.FuelRecords");
            DropTable("dbo.DriverVehicleRecords");
        }
    }
}
