namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingTileWidgetsToTileWidgetForConsistency : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TileWidgets", newName: "TileWidget");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TileWidget", newName: "TileWidgets");
        }
    }
}
