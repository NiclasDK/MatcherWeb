namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedcompositekeyattempt : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SubjectJobExperiences", newName: "JobexpSubj");
            DropForeignKey("dbo.JobSubs", "JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.JobSubs", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.JobSubs", new[] { "JobExperienceId" });
            DropIndex("dbo.JobSubs", new[] { "SubjectId" });
            RenameColumn(table: "dbo.JobexpSubj", name: "Subject_SubjectId", newName: "SubjectId");
            RenameColumn(table: "dbo.JobexpSubj", name: "JobExperience_JobExperienceId", newName: "JobExperienceId");
            RenameIndex(table: "dbo.JobexpSubj", name: "IX_JobExperience_JobExperienceId", newName: "IX_JobExperienceId");
            RenameIndex(table: "dbo.JobexpSubj", name: "IX_Subject_SubjectId", newName: "IX_SubjectId");
            DropPrimaryKey("dbo.JobexpSubj");
            AddPrimaryKey("dbo.JobexpSubj", new[] { "JobExperienceId", "SubjectId" });
            DropTable("dbo.JobSubs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobSubs",
                c => new
                    {
                        JobExperienceId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobExperienceId, t.SubjectId });
            
            DropPrimaryKey("dbo.JobexpSubj");
            AddPrimaryKey("dbo.JobexpSubj", new[] { "Subject_SubjectId", "JobExperience_JobExperienceId" });
            RenameIndex(table: "dbo.JobexpSubj", name: "IX_SubjectId", newName: "IX_Subject_SubjectId");
            RenameIndex(table: "dbo.JobexpSubj", name: "IX_JobExperienceId", newName: "IX_JobExperience_JobExperienceId");
            RenameColumn(table: "dbo.JobexpSubj", name: "JobExperienceId", newName: "JobExperience_JobExperienceId");
            RenameColumn(table: "dbo.JobexpSubj", name: "SubjectId", newName: "Subject_SubjectId");
            CreateIndex("dbo.JobSubs", "SubjectId");
            CreateIndex("dbo.JobSubs", "JobExperienceId");
            AddForeignKey("dbo.JobSubs", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
            AddForeignKey("dbo.JobSubs", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
            RenameTable(name: "dbo.JobexpSubj", newName: "SubjectJobExperiences");
        }
    }
}
