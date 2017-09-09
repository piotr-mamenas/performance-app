namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingTablePrefixMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tbl_Account", newName: "Account");
            RenameTable(name: "dbo.tbl_Partner", newName: "Partner");
            RenameTable(name: "dbo.tbl_Contact", newName: "Contact");
            RenameTable(name: "dbo.tbl_Institution", newName: "Institution");
            RenameTable(name: "dbo.tbl_Asset", newName: "Asset");
            RenameTable(name: "dbo.tbl_Currency", newName: "Currency");
            RenameTable(name: "dbo.tbl_Country", newName: "Country");
            RenameTable(name: "dbo.tbl_Roles", newName: "Roles");
            RenameTable(name: "dbo.tbl_UserRoles", newName: "UserRoles");
            RenameTable(name: "dbo.tbl_Users", newName: "Users");
            RenameTable(name: "dbo.tbl_UserClaims", newName: "UserClaims");
            RenameTable(name: "dbo.tbl_UserLogins", newName: "UserLogins");
            RenameTable(name: "dbo.tbl_PartnerAccounts", newName: "PartnersAccounts");
            RenameTable(name: "dbo.tbl_InstitutionPartners", newName: "PartnersInstitutions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PartnersInstitutions", newName: "tbl_InstitutionPartners");
            RenameTable(name: "dbo.PartnersAccounts", newName: "tbl_PartnerAccounts");
            RenameTable(name: "dbo.UserLogins", newName: "tbl_UserLogins");
            RenameTable(name: "dbo.UserClaims", newName: "tbl_UserClaims");
            RenameTable(name: "dbo.Users", newName: "tbl_Users");
            RenameTable(name: "dbo.UserRoles", newName: "tbl_UserRoles");
            RenameTable(name: "dbo.Roles", newName: "tbl_Roles");
            RenameTable(name: "dbo.Country", newName: "tbl_Country");
            RenameTable(name: "dbo.Currency", newName: "tbl_Currency");
            RenameTable(name: "dbo.Asset", newName: "tbl_Asset");
            RenameTable(name: "dbo.Institution", newName: "tbl_Institution");
            RenameTable(name: "dbo.Contact", newName: "tbl_Contact");
            RenameTable(name: "dbo.Partner", newName: "tbl_Partner");
            RenameTable(name: "dbo.Account", newName: "tbl_Account");
        }
    }
}
