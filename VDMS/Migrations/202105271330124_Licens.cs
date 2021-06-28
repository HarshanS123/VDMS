namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Licens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Renewal = c.DateTime(nullable: false),
                        Expiry = c.DateTime(nullable: false),
                        DsOffice = c.String(),
                        VehicleId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licenses", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Licenses", new[] { "VehicleId" });
            DropTable("dbo.Licenses");
        }
    }
}
