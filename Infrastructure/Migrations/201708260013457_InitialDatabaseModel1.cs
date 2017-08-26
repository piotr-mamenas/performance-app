namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Institution", "BankBicCode", c => c.String(maxLength: 11));
            DropColumn("dbo.tbl_Institution", "InstitutionBicCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Institution", "InstitutionBicCode", c => c.String(maxLength: 11));
            DropColumn("dbo.tbl_Institution", "BankBicCode");
        }
    }
}
