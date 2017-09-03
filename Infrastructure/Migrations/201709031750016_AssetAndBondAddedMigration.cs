namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetAndBondAddedMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Asset",
                c => new
                    {
                        AssetId = c.Int(nullable: false, identity: true),
                        AssetName = c.String(nullable: false),
                        AssetISIN = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        BondIssueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        BondMaturityDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        BondCouponRate = c.Decimal(precision: 18, scale: 2),
                        BondCouponAmount = c.Decimal(precision: 18, scale: 2),
                        BondFaceValue = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AssetId)
                .ForeignKey("dbo.tbl_Currency", t => t.AssetId)
                .Index(t => t.AssetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Asset", "AssetId", "dbo.tbl_Currency");
            DropIndex("dbo.tbl_Asset", new[] { "AssetId" });
            DropTable("dbo.tbl_Asset");
        }
    }
}
