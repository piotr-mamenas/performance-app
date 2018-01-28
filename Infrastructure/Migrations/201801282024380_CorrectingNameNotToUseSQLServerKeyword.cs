namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectingNameNotToUseSQLServerKeyword : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Return", newName: "InvestmentReturn");
            AddColumn("dbo.InvestmentReturn", "ReturnType", c => c.Int());
            DropColumn("dbo.InvestmentReturn", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvestmentReturn", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.InvestmentReturn", "ReturnType");
            RenameTable(name: "dbo.InvestmentReturn", newName: "Return");
        }
    }
}
