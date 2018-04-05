namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubjectAddedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Subjects", new[] { "JobExperience_JobExperienceId" });
            DropPrimaryKey("dbo.JobExperiences");
            AlterColumn("dbo.JobExperiences", "JobExperienceId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Subjects", "JobExperience_JobExperienceId", c => c.Int());
            AddPrimaryKey("dbo.JobExperiences", "JobExperienceId");
            CreateIndex("dbo.Subjects", "JobExperience_JobExperienceId");
            AddForeignKey("dbo.Subjects", "JobExperience_JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
            DropColumn("dbo.Certificates", "ApplicationUserId");
            DropColumn("dbo.JobExperiences", "ApplicationUserId");
            DropColumn("dbo.Languages", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Languages", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.JobExperiences", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Certificates", "ApplicationUserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Subjects", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Subjects", new[] { "JobExperience_JobExperienceId" });
            DropPrimaryKey("dbo.JobExperiences");
            AlterColumn("dbo.Subjects", "JobExperience_JobExperienceId", c => c.String(maxLength: 128));
            AlterColumn("dbo.JobExperiences", "JobExperienceId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.JobExperiences", "JobExperienceId");
            CreateIndex("dbo.Subjects", "JobExperience_JobExperienceId");
            AddForeignKey("dbo.Subjects", "JobExperience_JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
        }
    }
}
