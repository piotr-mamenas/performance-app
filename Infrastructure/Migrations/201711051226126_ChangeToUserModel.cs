namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmailConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Users", "EmailConfirmed");
            DropColumn("dbo.Users", "SecurityStamp");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "PhoneNumberConfirmed");
            DropColumn("dbo.Users", "TwoFactorEnabled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Boolean(nullable: false));
            DropTable("dbo.User1");
        }
    }
}
