namespace ITMatcherWeb.DataContext.BulletinMigrations
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
                        PictureId = c.String(nullable: false, maxLength: 128),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.PictureId);
            
            AddColumn("dbo.Bulletins", "Picture_PictureId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bulletins", "Picture_PictureId");
            AddForeignKey("dbo.Bulletins", "Picture_PictureId", "dbo.Pictures", "PictureId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bulletins", "Picture_PictureId", "dbo.Pictures");
            DropIndex("dbo.Bulletins", new[] { "Picture_PictureId" });
            DropColumn("dbo.Bulletins", "Picture_PictureId");
            DropTable("dbo.Pictures");
        }
    }
}
