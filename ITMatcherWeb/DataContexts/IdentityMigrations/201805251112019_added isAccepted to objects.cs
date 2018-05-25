namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedisAcceptedtoobjects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobExperiences", "isAccepted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Languages", "isAccepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Languages", "isAccepted");
            DropColumn("dbo.JobExperiences", "isAccepted");
        }
    }
}
