namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssetsToPortfolio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortfolioAssets",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false),
                        AssetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PortfolioId, t.AssetId })
                .ForeignKey("dbo.Portfolio", t => t.PortfolioId, cascadeDelete: true)
                .ForeignKey("dbo.Asset", t => t.AssetId, cascadeDelete: true)
                .Index(t => t.PortfolioId)
                .Index(t => t.AssetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PortfolioAssets", "AssetId", "dbo.Asset");
            DropForeignKey("dbo.PortfolioAssets", "PortfolioId", "dbo.Portfolio");
            DropIndex("dbo.PortfolioAssets", new[] { "AssetId" });
            DropIndex("dbo.PortfolioAssets", new[] { "PortfolioId" });
            DropTable("dbo.PortfolioAssets");
        }
    }
}
