namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandingUserConfiguration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
            AddColumn("dbo.Users", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            DropTable("dbo.User1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SecurityStamp = c.String(),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Users", "TwoFactorEnabled");
            DropColumn("dbo.Users", "SecurityStamp");
        }
    }
}
