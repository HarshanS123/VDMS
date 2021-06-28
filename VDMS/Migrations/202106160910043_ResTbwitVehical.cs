namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResTbwitVehical : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReceiverRecords", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.ReceiverRecords", new[] { "Vehicle_Id" });
            RenameColumn(table: "dbo.ReceiverRecords", name: "Vehicle_Id", newName: "VehicleId");
            AlterColumn("dbo.ReceiverRecords", "VehicleId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceiverRecords", "VehicleId");
            AddForeignKey("dbo.ReceiverRecords", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiverRecords", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.ReceiverRecords", new[] { "VehicleId" });
            AlterColumn("dbo.ReceiverRecords", "VehicleId", c => c.Int());
            RenameColumn(table: "dbo.ReceiverRecords", name: "VehicleId", newName: "Vehicle_Id");
            CreateIndex("dbo.ReceiverRecords", "Vehicle_Id");
            AddForeignKey("dbo.ReceiverRecords", "Vehicle_Id", "dbo.Vehicles", "Id");
        }
    }
}
