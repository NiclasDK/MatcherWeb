namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualpropsforUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educations", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Educations", new[] { "User_Id" });
            RenameColumn(table: "dbo.Educations", name: "User_Id", newName: "ApplicationUser_Id");
            AlterColumn("dbo.Educations", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Educations", "ApplicationUser_Id");
            AddForeignKey("dbo.Educations", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Educations", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Educations", "ApplicationUser_Id", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Educations", name: "ApplicationUser_Id", newName: "User_Id");
            CreateIndex("dbo.Educations", "User_Id");
            AddForeignKey("dbo.Educations", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
