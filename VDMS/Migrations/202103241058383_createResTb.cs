namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createResTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleAssignedRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssingData = c.DateTime(nullable: false),
                        TerminateDate = c.DateTime(),
                        ReceiverId = c.Int(nullable: false),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receivers", t => t.ReceiverId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.ReceiverId)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleAssignedRecords", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleAssignedRecords", "ReceiverId", "dbo.Receivers");
            DropIndex("dbo.VehicleAssignedRecords", new[] { "Vehicle_Id" });
            DropIndex("dbo.VehicleAssignedRecords", new[] { "ReceiverId" });
            DropTable("dbo.Receivers");
            DropTable("dbo.VehicleAssignedRecords");
        }
    }
}
