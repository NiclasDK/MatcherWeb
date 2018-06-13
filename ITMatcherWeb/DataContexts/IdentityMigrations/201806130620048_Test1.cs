namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Subjects", new[] { "JobExperienceId" });
            AlterColumn("dbo.Subjects", "JobExperienceId", c => c.Int());
            CreateIndex("dbo.Subjects", "JobExperienceId");
            AddForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Subjects", new[] { "JobExperienceId" });
            AlterColumn("dbo.Subjects", "JobExperienceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "JobExperienceId");
            AddForeignKey("dbo.Subjects", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
        }
    }
}
