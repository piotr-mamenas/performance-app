namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingNamesAddingContactConfigurationMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "tbl_Roles");
            RenameTable(name: "dbo.UserRoles", newName: "tbl_UserRoles");
            RenameTable(name: "dbo.Users", newName: "tbl_Users");
            RenameTable(name: "dbo.UserClaims", newName: "tbl_UserClaims");
            RenameTable(name: "dbo.UserLogins", newName: "tbl_UserLogins");
            DropIndex("dbo.tbl_Organization", new[] { "Id" });
            RenameColumn(table: "dbo.tbl_Organization", name: "Id", newName: "OrganizationId");
            RenameColumn(table: "dbo.tbl_Organization", name: "Name", newName: "OrganizationName");
            RenameColumn(table: "dbo.tbl_Partner", name: "Id", newName: "PartnerId");
            RenameColumn(table: "dbo.tbl_Partner", name: "Name", newName: "PartnerName");
            RenameColumn(table: "dbo.tbl_Partner", name: "Number", newName: "PartnerNumber");
            DropPrimaryKey("dbo.tbl_Organization");
            AddColumn("dbo.tbl_Partner", "Contact_Id", c => c.Int());
            AlterColumn("dbo.tbl_Organization", "OrganizationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tbl_Organization", "OrganizationId");
            CreateIndex("dbo.tbl_Organization", "OrganizationId");
            CreateIndex("dbo.tbl_Partner", "Contact_Id");
            AddForeignKey("dbo.tbl_Partner", "Contact_Id", "dbo.BaseContacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Partner", "Contact_Id", "dbo.BaseContacts");
            DropIndex("dbo.tbl_Partner", new[] { "Contact_Id" });
            DropIndex("dbo.tbl_Organization", new[] { "OrganizationId" });
            DropPrimaryKey("dbo.tbl_Organization");
            AlterColumn("dbo.tbl_Organization", "OrganizationId", c => c.Int(nullable: false));
            DropColumn("dbo.tbl_Partner", "Contact_Id");
            AddPrimaryKey("dbo.tbl_Organization", "Id");
            RenameColumn(table: "dbo.tbl_Partner", name: "PartnerNumber", newName: "Number");
            RenameColumn(table: "dbo.tbl_Partner", name: "PartnerName", newName: "Name");
            RenameColumn(table: "dbo.tbl_Partner", name: "PartnerId", newName: "Id");
            RenameColumn(table: "dbo.tbl_Organization", name: "OrganizationName", newName: "Name");
            RenameColumn(table: "dbo.tbl_Organization", name: "OrganizationId", newName: "Id");
            CreateIndex("dbo.tbl_Organization", "Id");
            RenameTable(name: "dbo.tbl_UserLogins", newName: "UserLogins");
            RenameTable(name: "dbo.tbl_UserClaims", newName: "UserClaims");
            RenameTable(name: "dbo.tbl_Users", newName: "Users");
            RenameTable(name: "dbo.tbl_UserRoles", newName: "UserRoles");
            RenameTable(name: "dbo.tbl_Roles", newName: "Roles");
        }
    }
}
