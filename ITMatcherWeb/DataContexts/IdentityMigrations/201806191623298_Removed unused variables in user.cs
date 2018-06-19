namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedunusedvariablesinuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Zipcode");
            DropColumn("dbo.AspNetUsers", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Zipcode", c => c.String());
        }
    }
}
