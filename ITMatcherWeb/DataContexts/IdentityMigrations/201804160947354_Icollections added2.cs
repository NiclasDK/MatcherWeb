namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Icollectionsadded2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Certificates", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobExperiences", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Certificates", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.JobExperiences", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Languages", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Certificates", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.JobExperiences", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Languages", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Certificates", "ApplicationUser_Id");
            CreateIndex("dbo.JobExperiences", "ApplicationUser_Id");
            CreateIndex("dbo.Languages", "ApplicationUser_Id");
            AddForeignKey("dbo.Certificates", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobExperiences", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobExperiences", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certificates", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Languages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.JobExperiences", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Certificates", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Languages", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.JobExperiences", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Certificates", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Languages", "ApplicationUser_Id");
            CreateIndex("dbo.JobExperiences", "ApplicationUser_Id");
            CreateIndex("dbo.Certificates", "ApplicationUser_Id");
            AddForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.JobExperiences", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Certificates", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
