namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlightCorrectionMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TileWidgets", "TileName", c => c.String(nullable: false));
            AddColumn("dbo.TileWidgets", "Icon_Name", c => c.String());
            DropColumn("dbo.TileWidgets", "TileIcon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TileWidgets", "TileIcon", c => c.String(nullable: false));
            DropColumn("dbo.TileWidgets", "Icon_Name");
            DropColumn("dbo.TileWidgets", "TileName");
        }
    }
}
