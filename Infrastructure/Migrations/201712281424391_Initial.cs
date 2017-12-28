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
                        PartnerId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Partner", t => t.PartnerId)
                .ForeignKey("dbo.WorkflowStatus", t => t.StatusId)
                .Index(t => t.PartnerId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Partner",
                c => new
                    {
                        PartnerId = c.Int(nullable: false, identity: true),
                        PartnerName = c.String(nullable: false, maxLength: 255),
                        PartnerNumber = c.String(nullable: false, maxLength: 30),
                        PartnerTypeId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PartnerId)
                .ForeignKey("dbo.PartnerType", t => t.PartnerTypeId)
                .Index(t => t.PartnerTypeId);
            
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
                "dbo.PartnerType",
                c => new
                    {
                        PartnerTypeId = c.Int(nullable: false, identity: true),
                        PartnerTypeName = c.String(nullable: false, maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PartnerTypeId);
            
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
                        ClassId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        BondIssueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        BondMaturityDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        BondCouponRate = c.Decimal(precision: 18, scale: 2),
                        BondCouponAmount = c.Decimal(precision: 18, scale: 2),
                        CurrencyId = c.Int(),
                        BondFaceValue = c.Decimal(precision: 18, scale: 2),
                        AssetType = c.Int(),
                    })
                .PrimaryKey(t => t.AssetId)
                .ForeignKey("dbo.AssetClass", t => t.ClassId)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .Index(t => t.ClassId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.AssetClass",
                c => new
                    {
                        AssetClassId = c.Int(nullable: false, identity: true),
                        AssetClassName = c.String(nullable: false),
                        AssetClassEnabled = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AssetClassId);
            
            CreateTable(
                "dbo.AssetPrice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Asset", t => t.AssetId)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .Index(t => t.AssetId)
                .Index(t => t.CurrencyId);
            
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
                "dbo.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionAmount = c.Decimal(nullable: false, precision: 16, scale: 3),
                        CurrencyId = c.Int(nullable: false),
                        AssetId = c.Int(nullable: false),
                        PortfolioId = c.Int(nullable: false),
                        PositionTimestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Asset", t => t.AssetId)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .ForeignKey("dbo.Portfolio", t => t.PortfolioId)
                .Index(t => t.CurrencyId)
                .Index(t => t.AssetId)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.WorkflowStatus",
                c => new
                    {
                        WorkflowStatusId = c.Int(nullable: false, identity: true),
                        WorkflowStatusName = c.String(nullable: false, maxLength: 255),
                        WorkflowStatusCaption = c.String(nullable: false, maxLength: 255),
                        WorkflowStatusCode = c.Int(nullable: false),
                        WorkflowEnabled = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WorkflowStatusId);
            
            CreateTable(
                "dbo.Workflow",
                c => new
                    {
                        WorkflowId = c.Int(nullable: false, identity: true),
                        WorkflowTimestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StatusId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WorkflowId)
                .ForeignKey("dbo.WorkflowStatus", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.ExchangeRate",
                c => new
                    {
                        ExchangeRateId = c.Int(nullable: false, identity: true),
                        BaseCurrencyId = c.Int(nullable: false),
                        TargetCurrencyId = c.Int(nullable: false),
                        ExchangeRateRate = c.Decimal(nullable: false, precision: 9, scale: 2),
                        ExchangeRateMax = c.Decimal(nullable: false, precision: 9, scale: 2),
                        ExchangeRateMin = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Timestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ExchangeRateId)
                .ForeignKey("dbo.Currency", t => t.BaseCurrencyId)
                .ForeignKey("dbo.Currency", t => t.TargetCurrencyId)
                .Index(t => t.BaseCurrencyId)
                .Index(t => t.TargetCurrencyId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageToken = c.String(nullable: false, maxLength: 128),
                        MessageLanguage = c.Int(nullable: false),
                        MessageContent = c.String(nullable: false, maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                        MessageType = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        ReportName = c.String(nullable: false, maxLength: 255),
                        ReportDescription = c.String(maxLength: 1024),
                        ReportHash = c.String(maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId);
            
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
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 255),
                        TaskDescription = c.String(maxLength: 1024),
                        TypeId = c.Int(nullable: false),
                        TaskJsonParameters = c.String(maxLength: 2048),
                        IsDeleted = c.Boolean(nullable: false),
                        ExportPath = c.String(maxLength: 255),
                        ImportPath = c.String(maxLength: 255),
                        TaskType = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.TaskType", t => t.TypeId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.TaskRun",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaskId = c.Int(nullable: false),
                        StartTimestamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTimestamp = c.DateTime(precision: 7, storeType: "datetime2"),
                        TaskProgress = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Task", t => t.TaskId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.TaskType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskTypeName = c.String(nullable: false),
                        TaskTypeDescription = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Language = c.Int(nullable: false),
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
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WorkflowTransition",
                c => new
                    {
                        WorkflowTransitionId = c.Int(nullable: false, identity: true),
                        WorkflowTransitionName = c.String(nullable: false, maxLength: 255),
                        WorkflowTransitionCaption = c.String(nullable: false, maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                        TransitionFrom_Id = c.Int(nullable: false),
                        TransitionTo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkflowTransitionId)
                .ForeignKey("dbo.WorkflowStatus", t => t.TransitionFrom_Id)
                .ForeignKey("dbo.WorkflowStatus", t => t.TransitionTo_Id)
                .Index(t => t.TransitionFrom_Id)
                .Index(t => t.TransitionTo_Id);
            
            CreateTable(
                "dbo.PartnerInstitutions",
                c => new
                    {
                        PartnerId = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.InstitutionId })
                .ForeignKey("dbo.Partner", t => t.PartnerId)
                .ForeignKey("dbo.Institution", t => t.InstitutionId)
                .Index(t => t.PartnerId)
                .Index(t => t.InstitutionId);
            
            CreateTable(
                "dbo.PortfolioAssets",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false),
                        AssetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PortfolioId, t.AssetId })
                .ForeignKey("dbo.Portfolio", t => t.PortfolioId)
                .ForeignKey("dbo.Asset", t => t.AssetId)
                .Index(t => t.PortfolioId)
                .Index(t => t.AssetId);
            
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
            DropForeignKey("dbo.WorkflowTransition", "TransitionTo_Id", "dbo.WorkflowStatus");
            DropForeignKey("dbo.WorkflowTransition", "TransitionFrom_Id", "dbo.WorkflowStatus");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Task", "TypeId", "dbo.TaskType");
            DropForeignKey("dbo.TaskRun", "TaskId", "dbo.Task");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.ExchangeRate", "TargetCurrencyId", "dbo.Currency");
            DropForeignKey("dbo.ExchangeRate", "BaseCurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Account", "StatusId", "dbo.WorkflowStatus");
            DropForeignKey("dbo.Workflow", "StatusId", "dbo.WorkflowStatus");
            DropForeignKey("dbo.Portfolio", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Position", "PortfolioId", "dbo.Portfolio");
            DropForeignKey("dbo.PortfolioAssets", "AssetId", "dbo.Asset");
            DropForeignKey("dbo.PortfolioAssets", "PortfolioId", "dbo.Portfolio");
            DropForeignKey("dbo.AssetPrice", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Position", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Position", "AssetId", "dbo.Asset");
            DropForeignKey("dbo.Country", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Asset", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.AssetPrice", "AssetId", "dbo.Asset");
            DropForeignKey("dbo.Asset", "ClassId", "dbo.AssetClass");
            DropForeignKey("dbo.Account", "PartnerId", "dbo.Partner");
            DropForeignKey("dbo.Partner", "PartnerTypeId", "dbo.PartnerType");
            DropForeignKey("dbo.PartnerInstitutions", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.PartnerInstitutions", "PartnerId", "dbo.Partner");
            DropForeignKey("dbo.Contact", "PartnerId", "dbo.Partner");
            DropIndex("dbo.PortfolioAssets", new[] { "AssetId" });
            DropIndex("dbo.PortfolioAssets", new[] { "PortfolioId" });
            DropIndex("dbo.PartnerInstitutions", new[] { "InstitutionId" });
            DropIndex("dbo.PartnerInstitutions", new[] { "PartnerId" });
            DropIndex("dbo.WorkflowTransition", new[] { "TransitionTo_Id" });
            DropIndex("dbo.WorkflowTransition", new[] { "TransitionFrom_Id" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.TaskRun", new[] { "TaskId" });
            DropIndex("dbo.Task", new[] { "TypeId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.ExchangeRate", new[] { "TargetCurrencyId" });
            DropIndex("dbo.ExchangeRate", new[] { "BaseCurrencyId" });
            DropIndex("dbo.Workflow", new[] { "StatusId" });
            DropIndex("dbo.Position", new[] { "PortfolioId" });
            DropIndex("dbo.Position", new[] { "AssetId" });
            DropIndex("dbo.Position", new[] { "CurrencyId" });
            DropIndex("dbo.Country", new[] { "CurrencyId" });
            DropIndex("dbo.AssetPrice", new[] { "CurrencyId" });
            DropIndex("dbo.AssetPrice", new[] { "AssetId" });
            DropIndex("dbo.Asset", new[] { "CurrencyId" });
            DropIndex("dbo.Asset", new[] { "ClassId" });
            DropIndex("dbo.Portfolio", new[] { "AccountId" });
            DropIndex("dbo.Contact", new[] { "PartnerId" });
            DropIndex("dbo.Partner", new[] { "PartnerTypeId" });
            DropIndex("dbo.Account", new[] { "StatusId" });
            DropIndex("dbo.Account", new[] { "PartnerId" });
            DropTable("dbo.User1");
            DropTable("dbo.PortfolioAssets");
            DropTable("dbo.PartnerInstitutions");
            DropTable("dbo.WorkflowTransition");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.TaskType");
            DropTable("dbo.TaskRun");
            DropTable("dbo.Task");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Report");
            DropTable("dbo.Message");
            DropTable("dbo.ExchangeRate");
            DropTable("dbo.Workflow");
            DropTable("dbo.WorkflowStatus");
            DropTable("dbo.Position");
            DropTable("dbo.Country");
            DropTable("dbo.Currency");
            DropTable("dbo.AssetPrice");
            DropTable("dbo.AssetClass");
            DropTable("dbo.Asset");
            DropTable("dbo.Portfolio");
            DropTable("dbo.PartnerType");
            DropTable("dbo.Institution");
            DropTable("dbo.Contact");
            DropTable("dbo.Partner");
            DropTable("dbo.Account");
        }
    }
}
