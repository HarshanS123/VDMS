namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createbasicTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufactures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.Countries VALUES('China'),('United States'),('Japan'),('Germany'),('India'),('Mexico'),('South Korea'),('Brazil'),('Spain'),('France'),('Thailand'),('Canada'),('Russia'),('Turkey'),('Czech Republic'),('United Kingdom'),('Indonesia'),('Slovakia'),('Italy'),('Iran'),('Hungary'),('South Africa'),('Malaysia'),('Poland'),('Romania'),('Morocco'), ('Portugal'), ('Argentina'), ('Belgium'), ('Sweden'), ('Uzbekistan'), ('Taiwan'), ('Vietnam'), ('Slovenia'), ('Pakistan'), ('Austria'), ('Netherlands'), ('Finland'), ('Algeria'), ('Colombia'), ('Philippines'), ('Ukraine')");
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleNo = c.String(),
                        TypeId = c.Int(nullable: false),
                        EngineNo = c.String(),
                        ChassiNo = c.String(),
                        Color = c.String(),
                        SeatingCapacity = c.Int(nullable: false),
                        DataOfFirstReg = c.DateTime(nullable: false),
                        CylinderCapacity = c.Int(nullable: false),
                        ManufacturedYear = c.Int(nullable: false),
                        ManufactureId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufactures", t => t.ManufactureId, cascadeDelete: true)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.VTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.ManufactureId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "TypeId", "dbo.VTypes");
            DropForeignKey("dbo.Vehicles", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Vehicles", "ManufactureId", "dbo.Manufactures");
            DropForeignKey("dbo.Manufactures", "CountryId", "dbo.Countries");
            DropIndex("dbo.Vehicles", new[] { "OwnerId" });
            DropIndex("dbo.Vehicles", new[] { "ManufactureId" });
            DropIndex("dbo.Vehicles", new[] { "TypeId" });
            DropIndex("dbo.Manufactures", new[] { "CountryId" });
            DropTable("dbo.VTypes");
            DropTable("dbo.Owners");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Countries");
            DropTable("dbo.Manufactures");
        }
    }
}
