namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddetailstoauthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Authors", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Authors", "About", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "About");
            DropColumn("dbo.Authors", "DOB");
            DropColumn("dbo.Authors", "Age");
        }
    }
}
