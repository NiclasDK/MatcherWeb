namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedJobExpobjvarinEnvironment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Environments", new[] { "JobExperienceId" });
            AlterColumn("dbo.Environments", "JobExperienceId", c => c.Int());
            CreateIndex("dbo.Environments", "JobExperienceId");
            AddForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Environments", new[] { "JobExperienceId" });
            AlterColumn("dbo.Environments", "JobExperienceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Environments", "JobExperienceId");
            AddForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
        }
    }
}
