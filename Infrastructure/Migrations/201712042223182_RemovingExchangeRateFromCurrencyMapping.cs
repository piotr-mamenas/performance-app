namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingExchangeRateFromCurrencyMapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExchangeRate", "Currency_Id", "dbo.Currency");
            DropIndex("dbo.ExchangeRate", new[] { "Currency_Id" });
            DropColumn("dbo.ExchangeRate", "Currency_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExchangeRate", "Currency_Id", c => c.Int());
            CreateIndex("dbo.ExchangeRate", "Currency_Id");
            AddForeignKey("dbo.ExchangeRate", "Currency_Id", "dbo.Currency", "CurrencyId");
        }
    }
}
