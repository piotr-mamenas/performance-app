namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountName = c.String(maxLength: 255),
                        AccountNumber = c.String(maxLength: 127),
                        OpenedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ClosedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Partner",
                c => new
                    {
                        PartnerId = c.Int(nullable: false, identity: true),
                        PartnerName = c.String(nullable: false, maxLength: 255),
                        PartnerNumber = c.String(nullable: false, maxLength: 30),
                        IsDeleted = c.Boolean(nullable: false),
                        PartnerType = c.Int(),
                    })
                .PrimaryKey(t => t.PartnerId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactName = c.String(nullable: false, maxLength: 255),
                        ContactFirstName = c.String(maxLength: 255),
                        ContactLastName = c.String(maxLength: 255),
                        ContactEmail = c.String(maxLength: 255),
                        ContactPhoneNumber = c.String(maxLength: 40),
                        PartnerId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Partner", t => t.PartnerId)
                .Index(t => t.PartnerId);
            
            CreateTable(
                "dbo.Institution",
                c => new
                    {
                        InstitutionId = c.Int(nullable: false, identity: true),
                        InstitutionName = c.String(nullable: false, maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                        BankBicCode = c.String(maxLength: 11),
                        InstitutionType = c.Int(),
                    })
                .PrimaryKey(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Portfolio",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        PortfolioName = c.String(nullable: false, maxLength: 255),
                        AccountId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PortfolioId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Asset",
                c => new
                    {
                        AssetId = c.Int(nullable: false, identity: true),
                        AssetName = c.String(nullable: false),
                        AssetISIN = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        BondIssueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        BondMaturityDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        BondCouponRate = c.Decimal(precision: 18, scale: 2),
                        BondCouponAmount = c.Decimal(precision: 18, scale: 2),
                        CurrencyId = c.Int(),
                        BondFaceValue = c.Decimal(precision: 18, scale: 2),
                        AssetClass = c.Int(),
                    })
                .PrimaryKey(t => t.AssetId)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionAmount = c.Decimal(nullable: false, precision: 16, scale: 3),
                        CurrencyId = c.Int(nullable: false),
                        AssetId = c.Int(nullable: false),
                        PositionTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .ForeignKey("dbo.Asset", t => t.AssetId)
                .Index(t => t.CurrencyId)
                .Index(t => t.AssetId);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(nullable: false, maxLength: 255),
                        CurrencyCode = c.String(maxLength: 3),
                        CurrencyEnabled = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 255),
                        CountryCode = c.String(maxLength: 2),
                        CurrencyId = c.Int(nullable: false),
                        CountryEnabled = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .Index(t => t.CurrencyId);
            
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
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        UserClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.UserClaimId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PartnerAccounts",
                c => new
                    {
                        PartnerId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.AccountId })
                .ForeignKey("dbo.Partner", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.PartnerInstitutions",
                c => new
                    {
                        PartnerId = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.InstitutionId })
                .ForeignKey("dbo.Partner", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.Institution", t => t.InstitutionId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.InstitutionId);
            
            CreateTable(
                "dbo.User1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SecurityStamp = c.String(),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Position", "AssetId", "dbo.Asset");
            DropForeignKey("dbo.Position", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Country", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Asset", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Portfolio", "AccountId", "dbo.Account");
            DropForeignKey("dbo.PartnerInstitutions", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.PartnerInstitutions", "PartnerId", "dbo.Partner");
            DropForeignKey("dbo.Contact", "PartnerId", "dbo.Partner");
            DropForeignKey("dbo.PartnerAccounts", "AccountId", "dbo.Account");
            DropForeignKey("dbo.PartnerAccounts", "PartnerId", "dbo.Partner");
            DropIndex("dbo.PartnerInstitutions", new[] { "InstitutionId" });
            DropIndex("dbo.PartnerInstitutions", new[] { "PartnerId" });
            DropIndex("dbo.PartnerAccounts", new[] { "AccountId" });
            DropIndex("dbo.PartnerAccounts", new[] { "PartnerId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Country", new[] { "CurrencyId" });
            DropIndex("dbo.Position", new[] { "AssetId" });
            DropIndex("dbo.Position", new[] { "CurrencyId" });
            DropIndex("dbo.Asset", new[] { "CurrencyId" });
            DropIndex("dbo.Portfolio", new[] { "AccountId" });
            DropIndex("dbo.Contact", new[] { "PartnerId" });
            DropTable("dbo.User1");
            DropTable("dbo.PartnerInstitutions");
            DropTable("dbo.PartnerAccounts");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Message");
            DropTable("dbo.Country");
            DropTable("dbo.Currency");
            DropTable("dbo.Position");
            DropTable("dbo.Asset");
            DropTable("dbo.Portfolio");
            DropTable("dbo.Institution");
            DropTable("dbo.Contact");
            DropTable("dbo.Partner");
            DropTable("dbo.Account");
        }
    }
}
