namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
                "dbo.tbl_Institution",
                c => new
                    {
                        InstitutionId = c.Int(nullable: false, identity: true),
                        InstitutionName = c.String(nullable: false, maxLength: 255),
                        InstitutionBicCode = c.String(maxLength: 11),
                        InstitutionType = c.Int(),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.tbl_Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 255),
                        CountryCode = c.String(maxLength: 2),
                        CountryEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.tbl_Currency",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(nullable: false, maxLength: 255),
                        CurrencyCode = c.String(maxLength: 2),
                        CurrencyEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
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
                "dbo.tbl_InstitutionPartners",
                c => new
                    {
                        PartnerId = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.InstitutionId })
                .ForeignKey("dbo.tbl_Partner", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.tbl_Institution", t => t.InstitutionId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.InstitutionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_UserRoles", "UserId", "dbo.tbl_Users");
            DropForeignKey("dbo.tbl_UserLogins", "UserId", "dbo.tbl_Users");
            DropForeignKey("dbo.tbl_UserClaims", "UserId", "dbo.tbl_Users");
            DropForeignKey("dbo.tbl_UserRoles", "RoleId", "dbo.tbl_Roles");
            DropForeignKey("dbo.tbl_Contact", "PartnerId", "dbo.tbl_Partner");
            DropForeignKey("dbo.tbl_InstitutionPartners", "InstitutionId", "dbo.tbl_Institution");
            DropForeignKey("dbo.tbl_InstitutionPartners", "PartnerId", "dbo.tbl_Partner");
            DropIndex("dbo.tbl_InstitutionPartners", new[] { "InstitutionId" });
            DropIndex("dbo.tbl_InstitutionPartners", new[] { "PartnerId" });
            DropIndex("dbo.tbl_UserLogins", new[] { "UserId" });
            DropIndex("dbo.tbl_UserClaims", new[] { "UserId" });
            DropIndex("dbo.tbl_UserRoles", new[] { "RoleId" });
            DropIndex("dbo.tbl_UserRoles", new[] { "UserId" });
            DropIndex("dbo.tbl_Contact", new[] { "PartnerId" });
            DropTable("dbo.tbl_InstitutionPartners");
            DropTable("dbo.tbl_UserLogins");
            DropTable("dbo.tbl_UserClaims");
            DropTable("dbo.tbl_Users");
            DropTable("dbo.tbl_UserRoles");
            DropTable("dbo.tbl_Roles");
            DropTable("dbo.tbl_Currency");
            DropTable("dbo.tbl_Country");
            DropTable("dbo.tbl_Institution");
            DropTable("dbo.tbl_Partner");
            DropTable("dbo.tbl_Contact");
        }
    }
}
