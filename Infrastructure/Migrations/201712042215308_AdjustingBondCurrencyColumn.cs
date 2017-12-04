namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustingBondCurrencyColumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Asset", name: "Currency_Id", newName: "CurrencyId");
            RenameIndex(table: "dbo.Asset", name: "IX_Currency_Id", newName: "IX_CurrencyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Asset", name: "IX_CurrencyId", newName: "IX_Currency_Id");
            RenameColumn(table: "dbo.Asset", name: "CurrencyId", newName: "Currency_Id");
        }
    }
}
