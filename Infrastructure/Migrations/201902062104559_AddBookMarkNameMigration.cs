namespace Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddBookMarkNameMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TileWidgetBookmark", "BookmarkName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TileWidgetBookmark", "BookmarkName");
        }
    }
}
