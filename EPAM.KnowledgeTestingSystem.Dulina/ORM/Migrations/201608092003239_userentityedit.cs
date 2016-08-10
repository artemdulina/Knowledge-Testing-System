namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userentityedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Username");
        }
    }
}
