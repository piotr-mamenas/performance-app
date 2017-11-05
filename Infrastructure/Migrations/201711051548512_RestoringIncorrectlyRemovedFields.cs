namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoringIncorrectlyRemovedFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            DropColumn("dbo.User1", "EmailConfirmed");
            DropColumn("dbo.User1", "PhoneNumber");
            DropColumn("dbo.User1", "PhoneNumberConfirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User1", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.User1", "PhoneNumber", c => c.String());
            AddColumn("dbo.User1", "EmailConfirmed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "PhoneNumberConfirmed");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "EmailConfirmed");
        }
    }
}
