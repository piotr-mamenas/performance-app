namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkflowObjectsMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkflowStatus",
                c => new
                    {
                        WorkflowStatusId = c.Int(nullable: false, identity: true),
                        WorkflowStatusName = c.String(nullable: false, maxLength: 255),
                        WorkflowStatusDesignation = c.String(nullable: false, maxLength: 255),
                        WorkflowStatusCode = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WorkflowStatusId);
            
            CreateTable(
                "dbo.Workflow",
                c => new
                    {
                        WorkflowId = c.Int(nullable: false, identity: true),
                        WorkflowTimestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StatusId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WorkflowId)
                .ForeignKey("dbo.WorkflowStatus", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.WorkflowTransition",
                c => new
                    {
                        WorkflowTransitionId = c.Int(nullable: false, identity: true),
                        WorkflowTransitionName = c.String(nullable: false, maxLength: 255),
                        WorkflowTransitionCaption = c.String(nullable: false, maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                        TransitionFrom_Id = c.Int(nullable: false),
                        TransitionTo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkflowTransitionId)
                .ForeignKey("dbo.WorkflowStatus", t => t.TransitionFrom_Id)
                .ForeignKey("dbo.WorkflowStatus", t => t.TransitionTo_Id)
                .Index(t => t.TransitionFrom_Id)
                .Index(t => t.TransitionTo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkflowTransition", "TransitionTo_Id", "dbo.WorkflowStatus");
            DropForeignKey("dbo.WorkflowTransition", "TransitionFrom_Id", "dbo.WorkflowStatus");
            DropForeignKey("dbo.Workflow", "StatusId", "dbo.WorkflowStatus");
            DropIndex("dbo.WorkflowTransition", new[] { "TransitionTo_Id" });
            DropIndex("dbo.WorkflowTransition", new[] { "TransitionFrom_Id" });
            DropIndex("dbo.Workflow", new[] { "StatusId" });
            DropTable("dbo.WorkflowTransition");
            DropTable("dbo.Workflow");
            DropTable("dbo.WorkflowStatus");
        }
    }
}
