namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfueltypetb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vehicles", "FuelTypesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "FuelTypesId");
            AddForeignKey("dbo.Vehicles", "FuelTypesId", "dbo.FuelTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "FuelTypesId", "dbo.FuelTypes");
            DropIndex("dbo.Vehicles", new[] { "FuelTypesId" });
            DropColumn("dbo.Vehicles", "FuelTypesId");
            DropTable("dbo.FuelTypes");
        }
    }
}
