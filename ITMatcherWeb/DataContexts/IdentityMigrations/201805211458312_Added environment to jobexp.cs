namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedenvironmenttojobexp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Environments", "JobExperience_JobExperienceId", c => c.Int());
            CreateIndex("dbo.Environments", "JobExperience_JobExperienceId");
            AddForeignKey("dbo.Environments", "JobExperience_JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Environments", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Environments", new[] { "JobExperience_JobExperienceId" });
            DropColumn("dbo.Environments", "JobExperience_JobExperienceId");
        }
    }
}
