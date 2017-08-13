namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingTableNameBaseContactToContact : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BaseContacts", newName: "tbl_Contact");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tbl_Contact", newName: "BaseContacts");
        }
    }
}
