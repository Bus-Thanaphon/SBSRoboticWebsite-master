namespace Robotic.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SBSU : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "No", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "No", c => c.Int(nullable: false));
        }
    }
}
