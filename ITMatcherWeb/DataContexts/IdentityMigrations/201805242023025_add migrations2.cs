namespace ITMatcherWeb.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrations2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clauses",
                c => new
                    {
                        clauseId = c.Int(nullable: false, identity: true),
                        workplace = c.String(),
                        endDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.clauseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clauses");
        }
    }
}
