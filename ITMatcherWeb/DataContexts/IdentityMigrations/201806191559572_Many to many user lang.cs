namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Manytomanyuserlang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Languages", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.UserLanguage",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.LanguageId })
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.LanguageId);
            
            DropColumn("dbo.Languages", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Languages", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.UserLanguage", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.UserLanguage", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserLanguage", new[] { "LanguageId" });
            DropIndex("dbo.UserLanguage", new[] { "Id" });
            DropTable("dbo.UserLanguage");
            CreateIndex("dbo.Languages", "ApplicationUser_Id");
            AddForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
