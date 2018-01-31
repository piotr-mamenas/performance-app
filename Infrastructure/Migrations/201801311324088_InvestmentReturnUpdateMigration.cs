namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvestmentReturnUpdateMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvestmentReturn", "PortfolioId", "dbo.Portfolio");
            DropIndex("dbo.InvestmentReturn", new[] { "AssetId" });
            DropIndex("dbo.InvestmentReturn", new[] { "PortfolioId" });
            RenameColumn(table: "dbo.InvestmentReturn", name: "CalculatedTime", newName: "ReturnTimestamp");
            CreateTable(
                "dbo.InvestmentReturnIncome",
                c => new
                    {
                        ReturnIncomeId = c.Int(nullable: false, identity: true),
                        ReturnIncomeTimestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IncomeAmount = c.Decimal(nullable: false, precision: 9, scale: 2),
                        ReturnId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReturnIncomeId)
                .ForeignKey("dbo.InvestmentReturn", t => t.ReturnId)
                .Index(t => t.ReturnId);
            
            CreateTable(
                "dbo.ReturnCalculationPeriod",
                c => new
                    {
                        ReturnCalculationPeriodId = c.Int(nullable: false, identity: true),
                        TimestampFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimestampTo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReturnId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReturnCalculationPeriodId)
                .ForeignKey("dbo.InvestmentReturn", t => t.ReturnId)
                .Index(t => t.ReturnId);
            
            AlterColumn("dbo.InvestmentReturn", "ReturnRate", c => c.Decimal(nullable: false, precision: 9, scale: 2));
            AlterColumn("dbo.InvestmentReturn", "AssetId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvestmentReturn", "AssetId");
            DropColumn("dbo.InvestmentReturn", "ReturnPeriodicity");
            DropColumn("dbo.InvestmentReturn", "PortfolioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvestmentReturn", "PortfolioId", c => c.Int());
            AddColumn("dbo.InvestmentReturn", "ReturnPeriodicity", c => c.Int());
            DropForeignKey("dbo.ReturnCalculationPeriod", "ReturnId", "dbo.InvestmentReturn");
            DropForeignKey("dbo.InvestmentReturnIncome", "ReturnId", "dbo.InvestmentReturn");
            DropIndex("dbo.ReturnCalculationPeriod", new[] { "ReturnId" });
            DropIndex("dbo.InvestmentReturnIncome", new[] { "ReturnId" });
            DropIndex("dbo.InvestmentReturn", new[] { "AssetId" });
            AlterColumn("dbo.InvestmentReturn", "AssetId", c => c.Int());
            AlterColumn("dbo.InvestmentReturn", "ReturnRate", c => c.Decimal(precision: 18, scale: 2));
            DropTable("dbo.ReturnCalculationPeriod");
            DropTable("dbo.InvestmentReturnIncome");
            RenameColumn(table: "dbo.InvestmentReturn", name: "ReturnTimestamp", newName: "CalculatedTime");
            CreateIndex("dbo.InvestmentReturn", "PortfolioId");
            CreateIndex("dbo.InvestmentReturn", "AssetId");
            AddForeignKey("dbo.InvestmentReturn", "PortfolioId", "dbo.Portfolio", "PortfolioId");
        }
    }
}
