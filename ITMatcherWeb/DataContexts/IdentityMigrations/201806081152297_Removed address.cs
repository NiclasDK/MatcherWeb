namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedaddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "Address_AddressId" });
            DropColumn("dbo.AspNetUsers", "Address_AddressId");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Zipcode = c.String(),
                        CityName = c.String(),
                        StreetName = c.String(),
                        StreetNumber = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            AddColumn("dbo.AspNetUsers", "Address_AddressId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Address_AddressId");
            AddForeignKey("dbo.AspNetUsers", "Address_AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
