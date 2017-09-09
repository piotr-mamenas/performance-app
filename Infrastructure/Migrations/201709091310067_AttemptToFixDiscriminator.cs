namespace Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AttemptToFixDiscriminator : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tbl_Asset", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Asset", "Discriminator", c => c.String(maxLength: 128));
        }
    }
}
