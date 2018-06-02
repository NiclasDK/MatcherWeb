namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedenumtypeandaddedJobExperiencerelationtoEnvironment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Environments", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Environments", new[] { "JobExperience_JobExperienceId" });
            RenameColumn(table: "dbo.Environments", name: "JobExperience_JobExperienceId", newName: "JobExperienceId");
            AlterColumn("dbo.Environments", "JobExperienceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Environments", "JobExperienceId");
            AddForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Environments", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Environments", new[] { "JobExperienceId" });
            AlterColumn("dbo.Environments", "JobExperienceId", c => c.Int());
            RenameColumn(table: "dbo.Environments", name: "JobExperienceId", newName: "JobExperience_JobExperienceId");
            CreateIndex("dbo.Environments", "JobExperience_JobExperienceId");
            AddForeignKey("dbo.Environments", "JobExperience_JobExperienceId", "dbo.JobExperiences", "JobExperienceId");
        }
    }
}
