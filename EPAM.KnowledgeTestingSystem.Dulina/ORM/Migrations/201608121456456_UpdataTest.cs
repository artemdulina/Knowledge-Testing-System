namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Test_Id", c => c.Int());
            CreateIndex("dbo.Users", "Test_Id");
            AddForeignKey("dbo.Users", "Test_Id", "dbo.Tests", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Test_Id", "dbo.Tests");
            DropIndex("dbo.Users", new[] { "Test_Id" });
            DropColumn("dbo.Users", "Test_Id");
        }
    }
}
