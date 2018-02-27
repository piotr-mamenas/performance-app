namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TileWidgetFeatureMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TileWidgets",
                c => new
                    {
                        TileWidgetId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        TileIcon = c.String(nullable: false),
                        LinkUrl = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TileWidgetId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TileWidgets", "UserId", "dbo.Users");
            DropIndex("dbo.TileWidgets", new[] { "UserId" });
            DropTable("dbo.TileWidgets");
        }
    }
}
