namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedclauseanddatepickerannotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "PictureId", "dbo.Bulletins");
            AddForeignKey("dbo.Pictures", "PictureId", "dbo.Bulletins", "BulletinId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "PictureId", "dbo.Bulletins");
            AddForeignKey("dbo.Pictures", "PictureId", "dbo.Bulletins", "BulletinId");
        }
    }
}
