namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedisAcceptedtosubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "IsAccepted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Languages", "IsAccepted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Languages", "IsAccepted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Subjects", "IsAccepted");
        }
    }
}
