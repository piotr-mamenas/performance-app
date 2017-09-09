namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChangesToAsset : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.tbl_Asset", name: "AssetType", newName: "AssetClass");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.tbl_Asset", name: "AssetClass", newName: "AssetType");
        }
    }
}
