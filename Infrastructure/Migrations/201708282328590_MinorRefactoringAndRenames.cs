namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorRefactoringAndRenames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Accounts", newName: "tbl_Account");
            RenameColumn(table: "dbo.tbl_Account", name: "Id", newName: "AccountId");
            RenameColumn(table: "dbo.tbl_Account", name: "Name", newName: "AccountName");
            RenameColumn(table: "dbo.tbl_Account", name: "Number", newName: "AccountNumber");
            AlterColumn("dbo.tbl_Account", "AccountName", c => c.String(maxLength: 255));
            AlterColumn("dbo.tbl_Account", "AccountNumber", c => c.String(maxLength: 127));
            AlterColumn("dbo.tbl_Account", "DateClosed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Account", "DateClosed", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_Account", "AccountNumber", c => c.String());
            AlterColumn("dbo.tbl_Account", "AccountName", c => c.String());
            RenameColumn(table: "dbo.tbl_Account", name: "AccountNumber", newName: "Number");
            RenameColumn(table: "dbo.tbl_Account", name: "AccountName", newName: "Name");
            RenameColumn(table: "dbo.tbl_Account", name: "AccountId", newName: "Id");
            RenameTable(name: "dbo.tbl_Account", newName: "Accounts");
        }
    }
}
