namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomanyuserlanguage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserLanguage", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLanguage", "LanguageId", "dbo.Languages");
            DropIndex("dbo.UserLanguage", new[] { "Id" });
            DropIndex("dbo.UserLanguage", new[] { "LanguageId" });
            CreateTable(
                "dbo.UserLanguages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        LanguageMastery = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LanguageId, t.UserId })
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.UserId);
            
            DropColumn("dbo.Languages", "Mastery");
            DropTable("dbo.UserLanguage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserLanguage",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.LanguageId });
            
            AddColumn("dbo.Languages", "Mastery", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserLanguages", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLanguages", "LanguageId", "dbo.Languages");
            DropIndex("dbo.UserLanguages", new[] { "UserId" });
            DropIndex("dbo.UserLanguages", new[] { "LanguageId" });
            DropTable("dbo.UserLanguages");
            CreateIndex("dbo.UserLanguage", "LanguageId");
            CreateIndex("dbo.UserLanguage", "Id");
            AddForeignKey("dbo.UserLanguage", "LanguageId", "dbo.Languages", "LanguageId", cascadeDelete: true);
            AddForeignKey("dbo.UserLanguage", "Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
