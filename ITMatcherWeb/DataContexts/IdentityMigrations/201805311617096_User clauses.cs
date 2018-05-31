namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userclauses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clauses", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Clauses", "ApplicationUser_Id");
            AddForeignKey("dbo.Clauses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clauses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Clauses", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Clauses", "ApplicationUser_Id");
        }
    }
}
