namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AndTaskTypeToTypeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskTypeName = c.String(nullable: false),
                        TaskTypeDescription = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Task", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Task", "TypeId");
            AddForeignKey("dbo.Task", "TypeId", "dbo.TaskType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "TypeId", "dbo.TaskType");
            DropIndex("dbo.Task", new[] { "TypeId" });
            DropColumn("dbo.Task", "TypeId");
            DropTable("dbo.TaskType");
        }
    }
}
