namespace ITMatcherWeb.DataContext.BulletinMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bulletins",
                c => new
                    {
                        BulletinId = c.String(nullable: false, maxLength: 128),
                        DateAdded = c.DateTime(),
                        Text = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BulletinId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bulletins");
        }
    }
}
