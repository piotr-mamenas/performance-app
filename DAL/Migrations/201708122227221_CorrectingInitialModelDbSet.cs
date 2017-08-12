namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectingInitialModelDbSet : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BasePartners", newName: "AssetManagers");
            DropColumn("dbo.AssetManagers", "Discriminator");
            DropTable("dbo.BaseContacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BaseContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AssetManagers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameTable(name: "dbo.AssetManagers", newName: "BasePartners");
        }
    }
}
