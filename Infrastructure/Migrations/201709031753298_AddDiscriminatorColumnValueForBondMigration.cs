namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiscriminatorColumnValueForBondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Asset", "AssetType", c => c.Int());
            AlterColumn("dbo.tbl_Asset", "Discriminator", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Asset", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.tbl_Asset", "AssetType");
        }
    }
}
