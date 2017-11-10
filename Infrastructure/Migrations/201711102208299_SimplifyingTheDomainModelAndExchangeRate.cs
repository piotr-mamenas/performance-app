namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimplifyingTheDomainModelAndExchangeRate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExchangeRate",
                c => new
                    {
                        ExchangeRateId = c.Int(nullable: false, identity: true),
                        BaseCurrencyId = c.Int(nullable: false),
                        TargetCurrencyId = c.Int(nullable: false),
                        ExchangeRateRate = c.Decimal(nullable: false, precision: 9, scale: 2),
                        ExchangeRateMax = c.Decimal(nullable: false, precision: 9, scale: 2),
                        ExchangeRateMin = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Timestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        Currency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ExchangeRateId)
                .ForeignKey("dbo.Currency", t => t.BaseCurrencyId)
                .ForeignKey("dbo.Currency", t => t.TargetCurrencyId)
                .ForeignKey("dbo.Currency", t => t.Currency_Id)
                .Index(t => t.BaseCurrencyId)
                .Index(t => t.TargetCurrencyId)
                .Index(t => t.Currency_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExchangeRate", "Currency_Id", "dbo.Currency");
            DropForeignKey("dbo.ExchangeRate", "TargetCurrencyId", "dbo.Currency");
            DropForeignKey("dbo.ExchangeRate", "BaseCurrencyId", "dbo.Currency");
            DropIndex("dbo.ExchangeRate", new[] { "Currency_Id" });
            DropIndex("dbo.ExchangeRate", new[] { "TargetCurrencyId" });
            DropIndex("dbo.ExchangeRate", new[] { "BaseCurrencyId" });
            DropTable("dbo.ExchangeRate");
        }
    }
}
