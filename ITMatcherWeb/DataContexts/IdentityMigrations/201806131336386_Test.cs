namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.Titles", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Environments", new[] { "JobExperienceId" });
            DropIndex("dbo.Subjects", new[] { "JobExperienceId" });
            DropIndex("dbo.Titles", new[] { "JobExperience_JobExperienceId" });
            RenameColumn(table: "dbo.Titles", name: "JobExperience_JobExperienceId", newName: "JobExperienceId");
            AddColumn("dbo.AspNetUsers", "Zipcode", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Environments", "JobExperienceId", c => c.Int());
            AlterColumn("dbo.Subjects", "JobExperienceId", c => c.Int());
            AlterColumn("dbo.Titles", "JobExperienceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Environments", "JobExperienceId");
            CreateIndex("dbo.Subjects", "JobExperienceId");
            CreateIndex("dbo.Titles", "JobExperienceId");
            AddForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
            AddForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
            AddForeignKey("dbo.Titles", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titles", "JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Titles", new[] { "JobExperienceId" });
            DropIndex("dbo.Subjects", new[] { "JobExperienceId" });
            DropIndex("dbo.Environments", new[] { "JobExperienceId" });
            AlterColumn("dbo.Titles", "JobExperienceId", c => c.Int());
            AlterColumn("dbo.Subjects", "JobExperienceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Environments", "JobExperienceId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Zipcode");
            RenameColumn(table: "dbo.Titles", name: "JobExperienceId", newName: "JobExperience_JobExperienceId");
            CreateIndex("dbo.Titles", "JobExperience_JobExperienceId");
            CreateIndex("dbo.Subjects", "JobExperienceId");
            CreateIndex("dbo.Environments", "JobExperienceId");
            AddForeignKey("dbo.Titles", "JobExperience_JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
            AddForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
            AddForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
        }
    }
}
