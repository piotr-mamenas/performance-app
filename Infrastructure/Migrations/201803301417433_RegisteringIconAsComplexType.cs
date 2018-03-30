namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisteringIconAsComplexType : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TileWidgets", name: "Icon_Name", newName: "IconName");
            AlterColumn("dbo.TileWidgets", "IconName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TileWidgets", "IconName", c => c.String());
            RenameColumn(table: "dbo.TileWidgets", name: "IconName", newName: "Icon_Name");
        }
    }
}
