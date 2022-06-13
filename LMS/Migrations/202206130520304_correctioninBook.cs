namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctioninBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Quantity");
        }
    }
}
