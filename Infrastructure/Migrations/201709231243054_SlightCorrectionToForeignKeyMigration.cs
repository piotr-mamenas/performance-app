namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlightCorrectionToForeignKeyMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Positions", newName: "Position");
            RenameColumn(table: "dbo.Position", name: "Id", newName: "PositionId");
            RenameColumn(table: "dbo.Position", name: "Amount", newName: "PositionAmount");
            RenameColumn(table: "dbo.Position", name: "Timestamp", newName: "PositionTime");
            AlterColumn("dbo.Position", "PositionAmount", c => c.Decimal(nullable: false, precision: 16, scale: 3));
            AlterColumn("dbo.Position", "PositionTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Position", "PositionTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Position", "PositionAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            RenameColumn(table: "dbo.Position", name: "PositionTime", newName: "Timestamp");
            RenameColumn(table: "dbo.Position", name: "PositionAmount", newName: "Amount");
            RenameColumn(table: "dbo.Position", name: "PositionId", newName: "Id");
            RenameTable(name: "dbo.Position", newName: "Positions");
        }
    }
}
