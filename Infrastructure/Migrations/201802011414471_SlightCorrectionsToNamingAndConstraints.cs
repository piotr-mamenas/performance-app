namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlightCorrectionsToNamingAndConstraints : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Portfolio", name: "Number", newName: "PortfolioNumber");
            RenameColumn(table: "dbo.AssetPrice", name: "Id", newName: "AssetPriceId");
            AddColumn("dbo.InvestmentReturn", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Portfolio", "PortfolioNumber", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Portfolio", "PortfolioNumber", c => c.String());
            DropColumn("dbo.InvestmentReturn", "Type");
            RenameColumn(table: "dbo.AssetPrice", name: "AssetPriceId", newName: "Id");
            RenameColumn(table: "dbo.Portfolio", name: "PortfolioNumber", newName: "Number");
        }
    }
}
