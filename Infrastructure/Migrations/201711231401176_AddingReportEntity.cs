namespace Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddingReportEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        ReportName = c.String(nullable: false, maxLength: 255),
                        ReportDescription = c.String(maxLength: 1024),
                        ReportHash = c.String(maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Report");
        }
    }
}
