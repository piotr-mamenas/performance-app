namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSessionTableMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSessions",
                c => new
                    {
                        UserSessionId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AuthenticationToken = c.String(nullable: false),
                        SessionStartTimestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SessionEndTimestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserSessionId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSessions", "UserId", "dbo.Users");
            DropIndex("dbo.UserSessions", new[] { "UserId" });
            DropTable("dbo.UserSessions");
        }
    }
}
