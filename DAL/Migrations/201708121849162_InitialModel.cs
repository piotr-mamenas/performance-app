namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.BaseOrganizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BasePartners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseOrganizations", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasePartners", "Organization_Id", "dbo.BaseOrganizations");
            DropIndex("dbo.BasePartners", new[] { "Organization_Id" });
            DropTable("dbo.BasePartners");
            DropTable("dbo.BaseOrganizations");
            DropTable("dbo.BaseContacts");
        }
    }
}
