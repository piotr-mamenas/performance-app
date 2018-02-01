namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandingPartnerInstitutionJoinTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Partner", name: "PartnerId", newName: "PartnerInstitutionsId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Partner", name: "PartnerInstitutionsId", newName: "PartnerId");
        }
    }
}
