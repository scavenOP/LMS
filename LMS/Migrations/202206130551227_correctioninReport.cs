namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctioninReport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Reports", "UserId", "dbo.Users");
            DropIndex("dbo.Reports", new[] { "UserId" });
            DropIndex("dbo.Reports", new[] { "StaffId" });
            AddColumn("dbo.Reports", "user_mail", c => c.String());
            DropColumn("dbo.Reports", "UserId");
            DropColumn("dbo.Reports", "StaffId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "StaffId", c => c.Int(nullable: false));
            AddColumn("dbo.Reports", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Reports", "user_mail");
            CreateIndex("dbo.Reports", "StaffId");
            CreateIndex("dbo.Reports", "UserId");
            AddForeignKey("dbo.Reports", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reports", "StaffId", "dbo.Staffs", "Id", cascadeDelete: true);
        }
    }
}
