namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PortfolioEntityAddedMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Portfolio",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        PortfolioName = c.String(nullable: false, maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PortfolioId);
            
            CreateTable(
                "dbo.PartnersPortfolios",
                c => new
                    {
                        PartnerId = c.Int(nullable: false),
                        PortfolioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.PortfolioId })
                .ForeignKey("dbo.Partner", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.Portfolio", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.PortfolioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartnersPortfolios", "PortfolioId", "dbo.Portfolio");
            DropForeignKey("dbo.PartnersPortfolios", "PartnerId", "dbo.Partner");
            DropIndex("dbo.PartnersPortfolios", new[] { "PortfolioId" });
            DropIndex("dbo.PartnersPortfolios", new[] { "PartnerId" });
            DropTable("dbo.PartnersPortfolios");
            DropTable("dbo.Portfolio");
        }
    }
}
