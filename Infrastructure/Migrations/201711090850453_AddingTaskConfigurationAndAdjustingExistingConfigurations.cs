namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTaskConfigurationAndAdjustingExistingConfigurations : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Asset", name: "CurrencyId", newName: "Currency_Id");
            RenameIndex(table: "dbo.Asset", name: "IX_CurrencyId", newName: "IX_Currency_Id");
            CreateTable(
                "dbo.AssetPrice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.Asset", t => t.AssetId)
                .Index(t => t.AssetId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 255),
                        TaskDescription = c.String(maxLength: 1024),
                        IsDeleted = c.Boolean(nullable: false),
                        ExportPath = c.String(maxLength: 255),
                        ImportPath = c.String(maxLength: 255),
                        TaskType = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Task", t => t.TaskId)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskRun", "TaskId", "dbo.Task");
            DropForeignKey("dbo.AssetPrice", "AssetId", "dbo.Asset");
            DropForeignKey("dbo.AssetPrice", "CurrencyId", "dbo.Currency");
            DropIndex("dbo.TaskRun", new[] { "TaskId" });
            DropIndex("dbo.AssetPrice", new[] { "CurrencyId" });
            DropIndex("dbo.AssetPrice", new[] { "AssetId" });
            DropTable("dbo.TaskRun");
            DropTable("dbo.Task");
            DropTable("dbo.AssetPrice");
            RenameIndex(table: "dbo.Asset", name: "IX_Currency_Id", newName: "IX_CurrencyId");
            RenameColumn(table: "dbo.Asset", name: "Currency_Id", newName: "CurrencyId");
        }
    }
}
