namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Explicitfkinsubject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Subjects", new[] { "JobExperience_JobExperienceId" });
            RenameColumn(table: "dbo.Subjects", name: "JobExperience_JobExperienceId", newName: "JobExperienceId");
            AlterColumn("dbo.Subjects", "JobExperienceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "JobExperienceId");
            AddForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Subjects", new[] { "JobExperienceId" });
            AlterColumn("dbo.Subjects", "JobExperienceId", c => c.Int());
            RenameColumn(table: "dbo.Subjects", name: "JobExperienceId", newName: "JobExperience_JobExperienceId");
            CreateIndex("dbo.Subjects", "JobExperience_JobExperienceId");
            AddForeignKey("dbo.Subjects", "JobExperience_JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
        }
    }
}
