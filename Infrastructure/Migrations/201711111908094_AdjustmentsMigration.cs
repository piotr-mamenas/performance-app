namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustmentsMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Language", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Language");
        }
    }
}
