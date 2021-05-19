namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetb : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Vehicles", name: "FuelTypesId", newName: "FuelTypeId");
            RenameIndex(table: "dbo.Vehicles", name: "IX_FuelTypesId", newName: "IX_FuelTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Vehicles", name: "IX_FuelTypeId", newName: "IX_FuelTypesId");
            RenameColumn(table: "dbo.Vehicles", name: "FuelTypeId", newName: "FuelTypesId");
        }
    }
}
