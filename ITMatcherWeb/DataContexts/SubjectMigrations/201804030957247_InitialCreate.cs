namespace ITMatcherWeb.DataContexts.SubjectMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.String(nullable: false, maxLength: 128),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        PercievedLevelOfSkill = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subjects");
        }
    }
}
