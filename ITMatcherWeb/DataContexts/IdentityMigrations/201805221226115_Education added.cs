namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Educationadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        EducationName = c.String(),
                        EducationLevel = c.Int(nullable: false),
                        SchoolName = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EducationId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AlterColumn("dbo.JobExperiences", "Employer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Educations", new[] { "User_Id" });
            AlterColumn("dbo.JobExperiences", "Employer", c => c.String());
            DropTable("dbo.Educations");
        }
    }
}
