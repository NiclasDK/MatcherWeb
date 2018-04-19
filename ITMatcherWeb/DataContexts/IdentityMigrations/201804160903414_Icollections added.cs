namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Icollectionsadded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "JobExperienceId");
            DropColumn("dbo.AspNetUsers", "LanguageId");
            DropColumn("dbo.AspNetUsers", "CertificateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CertificateId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "JobExperienceId", c => c.Int(nullable: false));
        }
    }
}
