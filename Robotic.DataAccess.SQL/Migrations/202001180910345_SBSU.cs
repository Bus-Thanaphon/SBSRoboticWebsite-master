namespace Robotic.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SBSU : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "UNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "UNo", c => c.String());
        }
    }
}
