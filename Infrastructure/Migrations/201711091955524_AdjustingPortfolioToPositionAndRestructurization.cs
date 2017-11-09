namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustingPortfolioToPositionAndRestructurization : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Position", name: "PositionTime", newName: "PositionTimestamp");
            AddColumn("dbo.Position", "PortfolioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Position", "PortfolioId");
            AddForeignKey("dbo.Position", "PortfolioId", "dbo.Portfolio", "PortfolioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Position", "PortfolioId", "dbo.Portfolio");
            DropIndex("dbo.Position", new[] { "PortfolioId" });
            DropColumn("dbo.Position", "PortfolioId");
            RenameColumn(table: "dbo.Position", name: "PositionTimestamp", newName: "PositionTime");
        }
    }
}
