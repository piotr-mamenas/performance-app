namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Organization",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(nullable: false, maxLength: 255),
                        Bic = c.String(),
                        OrganizationType = c.Int(),
                    })
                .PrimaryKey(t => t.OrganizationId);
            
            CreateTable(
                "dbo.tbl_Partner",
                c => new
                    {
                        PartnerId = c.Int(nullable: false, identity: true),
                        PartnerName = c.String(nullable: false, maxLength: 255),
                        PartnerNumber = c.String(nullable: false, maxLength: 30),
                        PartnerType = c.Int(),
                    })
                .PrimaryKey(t => t.PartnerId);
            
            CreateTable(
                "dbo.tbl_Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactName = c.String(nullable: false, maxLength: 255),
                        ContactFirstName = c.String(maxLength: 255),
                        ContactLastName = c.String(maxLength: 255),
                        ContactEmail = c.String(maxLength: 255),
                        ContactPhoneNumber = c.String(maxLength: 40),
                        PartnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.tbl_Partner", t => t.PartnerId)
                .Index(t => t.PartnerId);
            
            CreateTable(
                "dbo.tbl_Roles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.tbl_UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.tbl_Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.tbl_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tbl_Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.tbl_UserClaims",
                c => new
                    {
                        UserClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.UserClaimId)
                .ForeignKey("dbo.tbl_Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tbl_UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.tbl_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tbl_OrganizationPartners",
                c => new
                    {
                        PartnerId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.OrganizationId })
                .ForeignKey("dbo.tbl_Partner", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.tbl_Organization", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_UserRoles", "UserId", "dbo.tbl_Users");
            DropForeignKey("dbo.tbl_UserLogins", "UserId", "dbo.tbl_Users");
            DropForeignKey("dbo.tbl_UserClaims", "UserId", "dbo.tbl_Users");
            DropForeignKey("dbo.tbl_UserRoles", "RoleId", "dbo.tbl_Roles");
            DropForeignKey("dbo.tbl_OrganizationPartners", "OrganizationId", "dbo.tbl_Organization");
            DropForeignKey("dbo.tbl_OrganizationPartners", "PartnerId", "dbo.tbl_Partner");
            DropForeignKey("dbo.tbl_Contact", "PartnerId", "dbo.tbl_Partner");
            DropIndex("dbo.tbl_OrganizationPartners", new[] { "OrganizationId" });
            DropIndex("dbo.tbl_OrganizationPartners", new[] { "PartnerId" });
            DropIndex("dbo.tbl_UserLogins", new[] { "UserId" });
            DropIndex("dbo.tbl_UserClaims", new[] { "UserId" });
            DropIndex("dbo.tbl_UserRoles", new[] { "RoleId" });
            DropIndex("dbo.tbl_UserRoles", new[] { "UserId" });
            DropIndex("dbo.tbl_Contact", new[] { "PartnerId" });
            DropTable("dbo.tbl_OrganizationPartners");
            DropTable("dbo.tbl_UserLogins");
            DropTable("dbo.tbl_UserClaims");
            DropTable("dbo.tbl_Users");
            DropTable("dbo.tbl_UserRoles");
            DropTable("dbo.tbl_Roles");
            DropTable("dbo.tbl_Contact");
            DropTable("dbo.tbl_Partner");
            DropTable("dbo.tbl_Organization");
        }
    }
}
