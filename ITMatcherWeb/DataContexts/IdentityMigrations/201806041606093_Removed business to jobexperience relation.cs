namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedbusinesstojobexperiencerelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Businesses", "JobExperienceId", "dbo.JobExperiences");
            DropIndex("dbo.Businesses", new[] { "JobExperienceId" });
            RenameColumn(table: "dbo.Businesses", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Businesses", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            DropColumn("dbo.Businesses", "JobExperienceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Businesses", "JobExperienceId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Businesses", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Businesses", name: "ApplicationUser_Id", newName: "User_Id");
            CreateIndex("dbo.Businesses", "JobExperienceId");
            AddForeignKey("dbo.Businesses", "JobExperienceId", "dbo.JobExperiences", "JobExperienceId", cascadeDelete: true);
        }
    }
}
