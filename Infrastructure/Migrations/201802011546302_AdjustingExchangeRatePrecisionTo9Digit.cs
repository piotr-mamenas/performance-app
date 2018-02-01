namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustingExchangeRatePrecisionTo9Digit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExchangeRate", "ExchangeRateRate", c => c.Decimal(nullable: false, precision: 9, scale: 9));
            AlterColumn("dbo.ExchangeRate", "ExchangeRateMax", c => c.Decimal(nullable: false, precision: 9, scale: 9));
            AlterColumn("dbo.ExchangeRate", "ExchangeRateMin", c => c.Decimal(nullable: false, precision: 9, scale: 9));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExchangeRate", "ExchangeRateMin", c => c.Decimal(nullable: false, precision: 9, scale: 2));
            AlterColumn("dbo.ExchangeRate", "ExchangeRateMax", c => c.Decimal(nullable: false, precision: 9, scale: 2));
            AlterColumn("dbo.ExchangeRate", "ExchangeRateRate", c => c.Decimal(nullable: false, precision: 9, scale: 2));
        }
    }
}
