namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctioninauthor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Age", c => c.Int(nullable: false));
        }
    }
}
