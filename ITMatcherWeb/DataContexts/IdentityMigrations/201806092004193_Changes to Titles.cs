namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangestoTitles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Titles", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Titles", new[] { "JobExperience_JobExperienceId" });
            RenameColumn(table: "dbo.Titles", name: "JobExperience_JobExperienceId", newName: "JobExperienceId");
            AlterColumn("dbo.Titles", "JobExperienceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Titles", "JobExperienceId");
            AddForeignKey("dbo.Titles", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
            DropColumn("dbo.Businesses", "JobExperienceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Businesses", "JobExperienceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Titles", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Titles", new[] { "JobExperienceId" });
            AlterColumn("dbo.Titles", "JobExperienceId", c => c.Int());
            RenameColumn(table: "dbo.Titles", name: "JobExperienceId", newName: "JobExperience_JobExperienceId");
            CreateIndex("dbo.Titles", "JobExperience_JobExperienceId");
            AddForeignKey("dbo.Titles", "JobExperience_JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
        }
    }
}
