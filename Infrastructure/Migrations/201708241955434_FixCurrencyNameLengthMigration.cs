namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCurrencyNameLengthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Currency", "CurrencyCode", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Currency", "CurrencyCode", c => c.String(maxLength: 2));
        }
    }
}
