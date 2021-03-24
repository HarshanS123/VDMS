namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDriverTbandattr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.Appointments VALUES ('Combined Service'),('Attached SEC'),('Ministry Staff'),('Deputy Minister Staff'),('Other')");
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        NIC = c.String(maxLength: 15),
                        AppointmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId, cascadeDelete: true)
                .Index(t => t.AppointmentId);
            
            AlterColumn("dbo.Manufactures", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Countries", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Vehicles", "VehicleNo", c => c.String(maxLength: 15));
            AlterColumn("dbo.Vehicles", "EngineNo", c => c.String(maxLength: 100));
            AlterColumn("dbo.Vehicles", "ChassiNo", c => c.String(maxLength: 100));
            AlterColumn("dbo.Vehicles", "Color", c => c.String(maxLength: 50));
            AlterColumn("dbo.Owners", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.VTypes", "Name", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.Drivers", new[] { "AppointmentId" });
            AlterColumn("dbo.VTypes", "Name", c => c.String());
            AlterColumn("dbo.Owners", "Name", c => c.String());
            AlterColumn("dbo.Vehicles", "Color", c => c.String());
            AlterColumn("dbo.Vehicles", "ChassiNo", c => c.String());
            AlterColumn("dbo.Vehicles", "EngineNo", c => c.String());
            AlterColumn("dbo.Vehicles", "VehicleNo", c => c.String());
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Manufactures", "Name", c => c.String());
            DropTable("dbo.Drivers");
            DropTable("dbo.Appointments");
        }
    }
}
