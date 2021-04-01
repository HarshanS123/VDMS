namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newclStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.DriverVehicleRecords", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vehicles", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.FuelRecords", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Insurances", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.InsuranceClaims", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Owners", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ServiceRecords", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.VehicleAssignedRecords", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Receivers", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receivers", "Status");
            DropColumn("dbo.VehicleAssignedRecords", "Status");
            DropColumn("dbo.ServiceRecords", "Status");
            DropColumn("dbo.Owners", "Status");
            DropColumn("dbo.InsuranceClaims", "Status");
            DropColumn("dbo.Insurances", "Status");
            DropColumn("dbo.FuelRecords", "Status");
            DropColumn("dbo.Vehicles", "Status");
            DropColumn("dbo.DriverVehicleRecords", "Status");
            DropColumn("dbo.Drivers", "Status");
        }
    }
}
