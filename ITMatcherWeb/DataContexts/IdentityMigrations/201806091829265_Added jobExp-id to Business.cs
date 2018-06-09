namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedjobExpidtoBusiness : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Businesses", "JobExperienceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Businesses", "JobExperienceId");
        }
    }
}
