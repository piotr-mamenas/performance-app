namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateClosed = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_PartnerAccounts",
                c => new
                    {
                        PartnerId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartnerId, t.AccountId })
                .ForeignKey("dbo.tbl_Partner", t => t.PartnerId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.PartnerId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_PartnerAccounts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.tbl_PartnerAccounts", "PartnerId", "dbo.tbl_Partner");
            DropIndex("dbo.tbl_PartnerAccounts", new[] { "AccountId" });
            DropIndex("dbo.tbl_PartnerAccounts", new[] { "PartnerId" });
            DropTable("dbo.tbl_PartnerAccounts");
            DropTable("dbo.Accounts");
        }
    }
}
