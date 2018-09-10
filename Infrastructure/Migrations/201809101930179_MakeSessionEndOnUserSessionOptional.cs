namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeSessionEndOnUserSessionOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserSessions", "SessionEndTimestamp", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSessions", "SessionEndTimestamp", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
