namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtitleandenvironment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        TitleName = c.String(),
                        IsAccepted = c.Boolean(nullable: false),
                        JobExperience_JobExperienceId = c.Int(),
                    })
                .PrimaryKey(t => t.TitleId)
                .ForeignKey("dbo.JobExperiences", t => t.JobExperience_JobExperienceId)
                .Index(t => t.JobExperience_JobExperienceId);
            
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        EnvironmentId = c.Int(nullable: false, identity: true),
                        EnvironmentName = c.String(),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnvironmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titles", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Titles", new[] { "JobExperience_JobExperienceId" });
            DropTable("dbo.Environments");
            DropTable("dbo.Titles");
        }
    }
}
