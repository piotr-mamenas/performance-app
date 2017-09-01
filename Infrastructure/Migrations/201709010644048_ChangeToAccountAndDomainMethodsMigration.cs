namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToAccountAndDomainMethodsMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Account", "OpenedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.tbl_Account", "ClosedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.tbl_Account", "DateCreated");
            DropColumn("dbo.tbl_Account", "DateClosed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Account", "DateClosed", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.tbl_Account", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.tbl_Account", "ClosedDate");
            DropColumn("dbo.tbl_Account", "OpenedDate");
        }
    }
}
