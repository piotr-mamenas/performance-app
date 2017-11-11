namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingConcreteMessageTypes : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Message");

            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageToken = c.String(nullable: false, maxLength: 30),
                        MessageLanguage = c.Int(nullable: false),
                        MessageContent = c.String(nullable: false, maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                        MessageType = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId);
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageToken = c.String(nullable: false, maxLength: 30),
                        MessageLanguage = c.Int(nullable: false),
                        MessageContent = c.String(nullable: false, maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            DropTable("dbo.Message");
        }
    }
}
