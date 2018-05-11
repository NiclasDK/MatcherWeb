namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BulletinTypeadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bulletins", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bulletins", "Type", c => c.String());
        }
    }
}
