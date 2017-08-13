namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FixToCircularMappingOnPartner : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_Partner", "Contact_Id", "dbo.tbl_Contact");
            DropIndex("dbo.tbl_Partner", new[] { "Contact_Id" });
            DropColumn("dbo.tbl_Partner", "Contact_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Partner", "Contact_Id", c => c.Int());
            CreateIndex("dbo.tbl_Partner", "Contact_Id");
            AddForeignKey("dbo.tbl_Partner", "Contact_Id", "dbo.tbl_Contact", "ContactId");
        }
    }
}
