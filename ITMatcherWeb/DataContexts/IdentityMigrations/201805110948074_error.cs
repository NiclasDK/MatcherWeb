namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Languages", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Languages", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Languages", "ApplicationUser_Id");
            AddForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Languages", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Languages", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Languages", "ApplicationUser_Id");
            AddForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
