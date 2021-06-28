namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connectionaddedtoinsu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insurances", "IncuranceCompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Insurances", "IncuranceCompanyId");
            AddForeignKey("dbo.Insurances", "IncuranceCompanyId", "dbo.IncuranceCompanies", "Id", cascadeDelete: true);
            Sql("INSERT INTO dbo.IncuranceCompanies VALUES('AIA Insurance Lanka Ltd'),('AIG Insurance Limited'),('Allianz Insurance Lanka Ltd'),('Allianz Life Insurance Lanka Ltd'),('Amana Takaful Life PLC'),('Amana Takaful PLC'),('Arpico Insurance PLC'),('Ceylinco General Insurance Limited'),('Ceylinco Life Insurance Limited'),('Continental Insurance Lanka Ltd'),('Cooperative Insurance Company Ltd'),('Cooplife Insurance Limited'),('Fairfirst Insurance Limited'),('HNB Assurance PLC'),('HNB General Insurance Ltd'),('Janashakthi Insurance PLC'),('Life Insurance Corporation (Lanka) Ltd'),('LOLC General Insurance Limited'),('LOLC Life Assurance Limited'),('MBSL Insurance Company Limited'),('National Insurance Trust Fund'),('Orient Insurance Limited'),('People’s Insurance PLC'),('Sanasa General Insurance Company Limited'),('Sanasa Life Insurance Company Limited'),('Softlogic Life Insurance PLC'),('Sri Lanka Insurance Corporation Ltd'),('Union Assurance PLC')");
            Sql("INSERT INTO dbo.FuelTypes VALUES('Petrol-92 Octane'),('Petrol-95 Octane EURO 4'),('Diesel-Auto Diesel'),('Diesel-Lanka Super Diesel 4 star')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insurances", "IncuranceCompanyId", "dbo.IncuranceCompanies");
            DropIndex("dbo.Insurances", new[] { "IncuranceCompanyId" });
            DropColumn("dbo.Insurances", "IncuranceCompanyId");
        }
    }
}
