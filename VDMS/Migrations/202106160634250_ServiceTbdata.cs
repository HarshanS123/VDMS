namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceTbdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receivers", "Title", c => c.String());
            DropColumn("dbo.FuelRecords", "PreviousMeterReading");
            Sql("INSERT INTO dbo.ServiceCenters VALUES('Internal Server Center')");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FuelRecords", "PreviousMeterReading", c => c.Int(nullable: false));
            DropColumn("dbo.Receivers", "Title");
        }
    }
}
