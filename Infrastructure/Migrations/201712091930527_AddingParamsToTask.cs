namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingParamsToTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "TaskJsonParameters", c => c.String(maxLength: 2048));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task", "TaskJsonParameters");
        }
    }
}
