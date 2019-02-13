namespace Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTaskTableMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskRun", "TaskId", "dbo.Task");
            DropForeignKey("dbo.Task", "TypeId", "dbo.TaskType");
            DropIndex("dbo.Task", new[] { "TypeId" });
            DropIndex("dbo.TaskRun", new[] { "TaskId" });
            DropTable("dbo.Task");
            DropTable("dbo.TaskRun");
            DropTable("dbo.TaskType");
        }
        
        public override void Down()
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
            
            CreateTable(
                "dbo.TaskRun",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaskId = c.Int(nullable: false),
                        StartTimestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTimestamp = c.DateTime(precision: 7, storeType: "datetime2"),
                        TaskProgress = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 255),
                        TaskDescription = c.String(maxLength: 1024),
                        TypeId = c.Int(nullable: false),
                        TaskJsonParameters = c.String(maxLength: 2048),
                        IsDeleted = c.Boolean(nullable: false),
                        ExportPath = c.String(maxLength: 255),
                        ImportPath = c.String(maxLength: 255),
                        TaskType = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId);
            
            CreateIndex("dbo.TaskRun", "TaskId");
            CreateIndex("dbo.Task", "TypeId");
            AddForeignKey("dbo.Task", "TypeId", "dbo.TaskType", "Id");
            AddForeignKey("dbo.TaskRun", "TaskId", "dbo.Task", "TaskId");
        }
    }
}
