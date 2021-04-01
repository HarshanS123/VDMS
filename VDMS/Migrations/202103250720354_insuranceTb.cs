namespace VDMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insuranceTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PolicyNo = c.String(),
                        VehicleId = c.Int(nullable: false),
                        IncuranceCompany_Id = c.Int(),
                        IncuranceCompany_Id1 = c.Int(),
                        IncuranceCompanyId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IncuranceCompanies", t => t.IncuranceCompany_Id)
                .ForeignKey("dbo.IncuranceCompanies", t => t.IncuranceCompany_Id1)
                .ForeignKey("dbo.IncuranceCompanies", t => t.IncuranceCompanyId_Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.IncuranceCompany_Id)
                .Index(t => t.IncuranceCompany_Id1)
                .Index(t => t.IncuranceCompanyId_Id);
            
            CreateTable(
                "dbo.IncuranceCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InsuranceClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        InvoiceNo = c.String(),
                        Date = c.DateTime(nullable: false),
                        PaymentStatus = c.String(),
                        InsuranceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insurances", t => t.InsuranceId, cascadeDelete: true)
                .Index(t => t.InsuranceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insurances", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.InsuranceClaims", "InsuranceId", "dbo.Insurances");
            DropForeignKey("dbo.Insurances", "IncuranceCompanyId_Id", "dbo.IncuranceCompanies");
            DropForeignKey("dbo.Insurances", "IncuranceCompany_Id1", "dbo.IncuranceCompanies");
            DropForeignKey("dbo.Insurances", "IncuranceCompany_Id", "dbo.IncuranceCompanies");
            DropIndex("dbo.InsuranceClaims", new[] { "InsuranceId" });
            DropIndex("dbo.Insurances", new[] { "IncuranceCompanyId_Id" });
            DropIndex("dbo.Insurances", new[] { "IncuranceCompany_Id1" });
            DropIndex("dbo.Insurances", new[] { "IncuranceCompany_Id" });
            DropIndex("dbo.Insurances", new[] { "VehicleId" });
            DropTable("dbo.InsuranceClaims");
            DropTable("dbo.IncuranceCompanies");
            DropTable("dbo.Insurances");
        }
    }
}
