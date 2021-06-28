namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceiverRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssingData = c.DateTime(nullable: false),
                        TerminateDate = c.DateTime(),
                        ReceiverId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receivers", t => t.ReceiverId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.ReceiverId)
                .Index(t => t.Vehicle_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiverRecords", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.ReceiverRecords", "ReceiverId", "dbo.Receivers");
            DropIndex("dbo.ReceiverRecords", new[] { "Vehicle_Id" });
            DropIndex("dbo.ReceiverRecords", new[] { "ReceiverId" });
            DropTable("dbo.ReceiverRecords");
        }
    }
}
