namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserToBookmarkMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TileWidgetBookmark", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.TileWidgetBookmark", "UserId");
            AddForeignKey("dbo.TileWidgetBookmark", "UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TileWidgetBookmark", "UserId", "dbo.Users");
            DropIndex("dbo.TileWidgetBookmark", new[] { "UserId" });
            DropColumn("dbo.TileWidgetBookmark", "UserId");
        }
    }
}
