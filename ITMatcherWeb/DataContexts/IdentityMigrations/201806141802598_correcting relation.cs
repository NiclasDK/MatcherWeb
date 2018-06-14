namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctingrelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Titles", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Titles", new[] { "JobExperience_JobExperienceId" });
            DropColumn("dbo.Titles", "JobExperience_JobExperienceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Titles", "JobExperience_JobExperienceId", c => c.Int());
            CreateIndex("dbo.Titles", "JobExperience_JobExperienceId");
            AddForeignKey("dbo.Titles", "JobExperience_JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
        }
    }
}
