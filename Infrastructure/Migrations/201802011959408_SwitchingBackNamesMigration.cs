namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwitchingBackNamesMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Partner", name: "PartnerInstitutionsId", newName: "PartnerId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Partner", name: "PartnerId", newName: "PartnerInstitutionsId");
        }
    }
}
