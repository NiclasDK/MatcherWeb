namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Compositekeyjobsub : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.JobexpSubj", newName: "SubjectJobExperiences");
            RenameColumn(table: "dbo.SubjectJobExperiences", name: "JobExperienceId", newName: "JobExperience_JobExperienceId");
            RenameColumn(table: "dbo.SubjectJobExperiences", name: "SubjectId", newName: "Subject_SubjectId");
            RenameIndex(table: "dbo.SubjectJobExperiences", name: "IX_SubjectId", newName: "IX_Subject_SubjectId");
            RenameIndex(table: "dbo.SubjectJobExperiences", name: "IX_JobExperienceId", newName: "IX_JobExperience_JobExperienceId");
            DropPrimaryKey("dbo.SubjectJobExperiences");
            CreateTable(
                "dbo.JobSubs",
                c => new
                    {
                        JobExperienceId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobExperienceId, t.SubjectId })
                .ForeignKey("dbo.JobExperiences", t => t.JobExperienceId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.JobExperienceId)
                .Index(t => t.SubjectId);
            
            AddPrimaryKey("dbo.SubjectJobExperiences", new[] { "Subject_SubjectId", "JobExperience_JobExperienceId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobSubs", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.JobSubs", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.JobSubs", new[] { "SubjectId" });
            DropIndex("dbo.JobSubs", new[] { "JobExperienceId" });
            DropPrimaryKey("dbo.SubjectJobExperiences");
            DropTable("dbo.JobSubs");
            AddPrimaryKey("dbo.SubjectJobExperiences", new[] { "JobExperienceId", "SubjectId" });
            RenameIndex(table: "dbo.SubjectJobExperiences", name: "IX_JobExperience_JobExperienceId", newName: "IX_JobExperienceId");
            RenameIndex(table: "dbo.SubjectJobExperiences", name: "IX_Subject_SubjectId", newName: "IX_SubjectId");
            RenameColumn(table: "dbo.SubjectJobExperiences", name: "Subject_SubjectId", newName: "SubjectId");
            RenameColumn(table: "dbo.SubjectJobExperiences", name: "JobExperience_JobExperienceId", newName: "JobExperienceId");
            RenameTable(name: "dbo.SubjectJobExperiences", newName: "JobexpSubj");
        }
    }
}
