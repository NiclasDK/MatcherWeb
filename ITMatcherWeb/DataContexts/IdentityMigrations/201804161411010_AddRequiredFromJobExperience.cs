namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredFromJobExperience : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobExperiences", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.JobExperiences", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.JobExperiences", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.JobExperiences", "ApplicationUser_Id");
            AddForeignKey("dbo.JobExperiences", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobExperiences", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.JobExperiences", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.JobExperiences", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.JobExperiences", "ApplicationUser_Id");
            AddForeignKey("dbo.JobExperiences", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
