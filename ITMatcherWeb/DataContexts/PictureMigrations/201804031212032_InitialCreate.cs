namespace ITMatcherWeb.DataContexts.PictureMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.Bulletins",
                c => new
                    {
                        BulletinId = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(),
                        Text = c.String(),
                        Active = c.Boolean(nullable: false),
                        Type = c.String(),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BulletinId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "PictureId", "dbo.Bulletins");
            DropIndex("dbo.Pictures", new[] { "PictureId" });
            DropTable("dbo.Bulletins");
            DropTable("dbo.Pictures");
        }
    }
}
