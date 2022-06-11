namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changechatagorydatatype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CatagoryId", "dbo.Catagories");
            DropIndex("dbo.Books", new[] { "CatagoryId" });
            AddColumn("dbo.Books", "Catagory", c => c.String());
            DropColumn("dbo.Books", "CatagoryId");
            DropTable("dbo.Catagories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "CatagoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Catagory");
            CreateIndex("dbo.Books", "CatagoryId");
            AddForeignKey("dbo.Books", "CatagoryId", "dbo.Catagories", "Id", cascadeDelete: true);
        }
    }
}
