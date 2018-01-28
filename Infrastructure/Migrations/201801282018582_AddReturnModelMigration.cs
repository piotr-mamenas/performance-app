namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReturnModelMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Return",
                c => new
                    {
                        ReturnId = c.Int(nullable: false, identity: true),
                        CalculatedTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        ReturnPeriodicity = c.Int(),
                        ReturnRate = c.Decimal(precision: 18, scale: 2),
                        AssetId = c.Int(),
                        PortfolioId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ReturnId)
                .ForeignKey("dbo.Asset", t => t.AssetId)
                .ForeignKey("dbo.Portfolio", t => t.PortfolioId)
                .Index(t => t.AssetId)
                .Index(t => t.PortfolioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Return", "PortfolioId", "dbo.Portfolio");
            DropForeignKey("dbo.Return", "AssetId", "dbo.Asset");
            DropIndex("dbo.Return", new[] { "PortfolioId" });
            DropIndex("dbo.Return", new[] { "AssetId" });
            DropTable("dbo.Return");
        }
    }
}
