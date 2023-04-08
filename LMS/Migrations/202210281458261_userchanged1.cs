namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userchanged1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Phone", c => c.Long(nullable: false));
            AddColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
