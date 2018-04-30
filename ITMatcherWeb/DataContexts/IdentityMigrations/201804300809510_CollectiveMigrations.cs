namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectiveMigrations : DbMigration
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
                        Type = c.String(),
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
                .ForeignKey("dbo.Bulletins", t => t.PictureId)
                .Index(t => t.PictureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "PictureId", "dbo.Bulletins");
            DropIndex("dbo.Pictures", new[] { "PictureId" });
            DropTable("dbo.Pictures");
            DropTable("dbo.Bulletins");
        }
    }
}
