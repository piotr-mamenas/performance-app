namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WidgetBookmarkMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TileWidgetBookmark",
                c => new
                    {
                        TileWidgetBookmarkId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TileWidgetBookmarkId);
            
            AddColumn("dbo.TileWidget", "BookmarkId", c => c.Int(nullable: false));
            CreateIndex("dbo.TileWidget", "BookmarkId");
            AddForeignKey("dbo.TileWidget", "BookmarkId", "dbo.TileWidgetBookmark", "TileWidgetBookmarkId");
            DropColumn("dbo.TileWidget", "LinkUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TileWidget", "LinkUrl", c => c.String());
            DropForeignKey("dbo.TileWidget", "BookmarkId", "dbo.TileWidgetBookmark");
            DropIndex("dbo.TileWidget", new[] { "BookmarkId" });
            DropColumn("dbo.TileWidget", "BookmarkId");
            DropTable("dbo.TileWidgetBookmark");
        }
    }
}
