namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "booksissued", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "booksissued");
        }
    }
}
