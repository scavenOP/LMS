namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedColorField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Color", c => c.String());
        }
    }
}
