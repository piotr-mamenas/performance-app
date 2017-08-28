namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustDatetimeFieldTypeMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Account", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.tbl_Account", "DateClosed", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Account", "DateClosed", c => c.DateTime());
            AlterColumn("dbo.tbl_Account", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
