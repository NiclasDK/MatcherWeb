namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Manytomanyrelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bulletins",
                c => new
                    {
                        BulletinId = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(),
                        Headline = c.String(),
                        Text = c.String(),
                        Active = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BulletinId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false),
                        PicturePath = c.String(),
                        BulletinId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.Bulletins", t => t.PictureId, cascadeDelete: true)
                .Index(t => t.PictureId);
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        BusinessId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BusinessId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Available = c.Boolean(nullable: false),
                        ActivelySeeking = c.Boolean(nullable: false),
                        AcceptedUseOfData = c.Boolean(nullable: false),
                        ExpectedHourlySalary = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Zipcode = c.String(),
                        City = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        CertificateId = c.String(nullable: false, maxLength: 128),
                        DateOfCertification = c.DateTime(),
                        Name = c.String(),
                        CertificationProvider = c.String(),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CertificateId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Clauses",
                c => new
                    {
                        clauseId = c.Int(nullable: false, identity: true),
                        workplace = c.String(),
                        endDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.clauseId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        EducationName = c.String(),
                        EducationLevel = c.Int(nullable: false),
                        SchoolName = c.String(),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EducationId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.JobExperiences",
                c => new
                    {
                        JobExperienceId = c.Int(nullable: false, identity: true),
                        Employer = c.String(nullable: false),
                        DateOfEmployment = c.DateTime(),
                        DateOfExit = c.DateTime(),
                        IsAccepted = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.JobExperienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        EnvironmentId = c.Int(nullable: false, identity: true),
                        EnvironmentName = c.String(),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        PercievedLevelOfSkill = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        TitleName = c.String(),
                        IsAccepted = c.Boolean(nullable: false),
                        JobExperience_JobExperienceId = c.Int(),
                    })
                .PrimaryKey(t => t.TitleId)
                .ForeignKey("dbo.JobExperiences", t => t.JobExperience_JobExperienceId)
                .Index(t => t.JobExperience_JobExperienceId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mastery = c.Int(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LanguageId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.JobexpEnv",
                c => new
                    {
                        JobExperienceId = c.Int(nullable: false),
                        EnvironmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobExperienceId, t.EnvironmentId })
                .ForeignKey("dbo.JobExperiences", t => t.JobExperienceId, cascadeDelete: true)
                .ForeignKey("dbo.Environments", t => t.EnvironmentId, cascadeDelete: true)
                .Index(t => t.JobExperienceId)
                .Index(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.JobexpSubj",
                c => new
                    {
                        JobExperienceId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobExperienceId, t.SubjectId })
                .ForeignKey("dbo.JobExperiences", t => t.JobExperienceId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.JobExperienceId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.JobexpTit",
                c => new
                    {
                        JobExperienceId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobExperienceId, t.TitleId })
                .ForeignKey("dbo.JobExperiences", t => t.JobExperienceId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.JobExperienceId)
                .Index(t => t.TitleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Languages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobExperiences", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobexpTit", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.JobexpTit", "JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.Titles", "JobExperience_JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.JobexpSubj", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.JobexpSubj", "JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.JobexpEnv", "EnvironmentId", "dbo.Environments");
            DropForeignKey("dbo.JobexpEnv", "JobExperienceId", "dbo.JobExperiences");
            DropForeignKey("dbo.Educations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clauses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certificates", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Businesses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pictures", "PictureId", "dbo.Bulletins");
            DropIndex("dbo.JobexpTit", new[] { "TitleId" });
            DropIndex("dbo.JobexpTit", new[] { "JobExperienceId" });
            DropIndex("dbo.JobexpSubj", new[] { "SubjectId" });
            DropIndex("dbo.JobexpSubj", new[] { "JobExperienceId" });
            DropIndex("dbo.JobexpEnv", new[] { "EnvironmentId" });
            DropIndex("dbo.JobexpEnv", new[] { "JobExperienceId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Languages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Titles", new[] { "JobExperience_JobExperienceId" });
            DropIndex("dbo.JobExperiences", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Educations", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Clauses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Certificates", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Businesses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Pictures", new[] { "PictureId" });
            DropTable("dbo.JobexpTit");
            DropTable("dbo.JobexpSubj");
            DropTable("dbo.JobexpEnv");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Languages");
            DropTable("dbo.Titles");
            DropTable("dbo.Subjects");
            DropTable("dbo.Environments");
            DropTable("dbo.JobExperiences");
            DropTable("dbo.Educations");
            DropTable("dbo.Clauses");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Certificates");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Businesses");
            DropTable("dbo.Pictures");
            DropTable("dbo.Bulletins");
        }
    }
}
