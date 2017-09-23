namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        AssetId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .ForeignKey("dbo.Asset", t => t.AssetId)
                .Index(t => t.CurrencyId)
                .Index(t => t.AssetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "AssetId", "dbo.Asset");
            DropForeignKey("dbo.Positions", "CurrencyId", "dbo.Currency");
            DropIndex("dbo.Positions", new[] { "AssetId" });
            DropIndex("dbo.Positions", new[] { "CurrencyId" });
            DropTable("dbo.Positions");
        }
    }
}
