namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogicalDeletionMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Contact", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_Partner", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_Institution", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_Country", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_Currency", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Currency", "IsDeleted");
            DropColumn("dbo.tbl_Country", "IsDeleted");
            DropColumn("dbo.tbl_Institution", "IsDeleted");
            DropColumn("dbo.tbl_Partner", "IsDeleted");
            DropColumn("dbo.tbl_Contact", "IsDeleted");
        }
    }
}
