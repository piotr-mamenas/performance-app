namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingContactConfigurationFixed : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BaseContacts", name: "Id", newName: "ContactId");
            RenameColumn(table: "dbo.BaseContacts", name: "Name", newName: "ContactName");
            RenameColumn(table: "dbo.BaseContacts", name: "FirstName", newName: "ContactFirstName");
            RenameColumn(table: "dbo.BaseContacts", name: "LastName", newName: "ContactLastName");
            RenameColumn(table: "dbo.BaseContacts", name: "Email", newName: "ContactEmail");
            RenameColumn(table: "dbo.BaseContacts", name: "PhoneNumber", newName: "ContactPhoneNumber");
            AlterColumn("dbo.BaseContacts", "ContactName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.BaseContacts", "ContactFirstName", c => c.String(maxLength: 255));
            AlterColumn("dbo.BaseContacts", "ContactLastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.BaseContacts", "ContactEmail", c => c.String(maxLength: 255));
            AlterColumn("dbo.BaseContacts", "ContactPhoneNumber", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BaseContacts", "ContactPhoneNumber", c => c.String());
            AlterColumn("dbo.BaseContacts", "ContactEmail", c => c.String());
            AlterColumn("dbo.BaseContacts", "ContactLastName", c => c.String());
            AlterColumn("dbo.BaseContacts", "ContactFirstName", c => c.String());
            AlterColumn("dbo.BaseContacts", "ContactName", c => c.String());
            RenameColumn(table: "dbo.BaseContacts", name: "ContactPhoneNumber", newName: "PhoneNumber");
            RenameColumn(table: "dbo.BaseContacts", name: "ContactEmail", newName: "Email");
            RenameColumn(table: "dbo.BaseContacts", name: "ContactLastName", newName: "LastName");
            RenameColumn(table: "dbo.BaseContacts", name: "ContactFirstName", newName: "FirstName");
            RenameColumn(table: "dbo.BaseContacts", name: "ContactName", newName: "Name");
            RenameColumn(table: "dbo.BaseContacts", name: "ContactId", newName: "Id");
        }
    }
}
