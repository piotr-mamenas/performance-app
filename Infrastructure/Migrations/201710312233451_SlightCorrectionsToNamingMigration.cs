namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlightCorrectionsToNamingMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PartnersAccounts", newName: "PartnerAccounts");
            RenameTable(name: "dbo.PartnersInstitutions", newName: "PartnerInstitutions");
            RenameTable(name: "dbo.PartnersPortfolios", newName: "PartnerPortfolios");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PartnerPortfolios", newName: "PartnersPortfolios");
            RenameTable(name: "dbo.PartnerInstitutions", newName: "PartnersInstitutions");
            RenameTable(name: "dbo.PartnerAccounts", newName: "PartnersAccounts");
        }
    }
}
