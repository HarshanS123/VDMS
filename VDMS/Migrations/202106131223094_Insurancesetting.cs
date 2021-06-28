namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurancesetting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Insurances", "IncuranceCompany_Id", "dbo.IncuranceCompanies");
            DropForeignKey("dbo.Insurances", "IncuranceCompany_Id1", "dbo.IncuranceCompanies");
            DropForeignKey("dbo.Insurances", "IncuranceCompanyId_Id", "dbo.IncuranceCompanies");
            DropIndex("dbo.Insurances", new[] { "IncuranceCompany_Id" });
            DropIndex("dbo.Insurances", new[] { "IncuranceCompany_Id1" });
            DropIndex("dbo.Insurances", new[] { "IncuranceCompanyId_Id" });
            DropColumn("dbo.Insurances", "IncuranceCompany_Id");
            DropColumn("dbo.Insurances", "IncuranceCompany_Id1");
            DropColumn("dbo.Insurances", "IncuranceCompanyId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Insurances", "IncuranceCompanyId_Id", c => c.Int());
            AddColumn("dbo.Insurances", "IncuranceCompany_Id1", c => c.Int());
            AddColumn("dbo.Insurances", "IncuranceCompany_Id", c => c.Int());
            CreateIndex("dbo.Insurances", "IncuranceCompanyId_Id");
            CreateIndex("dbo.Insurances", "IncuranceCompany_Id1");
            CreateIndex("dbo.Insurances", "IncuranceCompany_Id");
            AddForeignKey("dbo.Insurances", "IncuranceCompanyId_Id", "dbo.IncuranceCompanies", "Id");
            AddForeignKey("dbo.Insurances", "IncuranceCompany_Id1", "dbo.IncuranceCompanies", "Id");
            AddForeignKey("dbo.Insurances", "IncuranceCompany_Id", "dbo.IncuranceCompanies", "Id");
        }
    }
}
