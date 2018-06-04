namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedbusiness : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        BusinessId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        JobExperienceId = c.Int(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BusinessId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.JobExperiences", t => t.JobExperienceId, cascadeDelete: true)
                .Index(t => t.JobExperienceId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Businesses", "JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.Businesses", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Businesses", new[] { "User_Id" });
            DropIndex("dbo.Businesses", new[] { "JobExperienceId" });
            DropTable("dbo.Businesses");
        }
    }
}
