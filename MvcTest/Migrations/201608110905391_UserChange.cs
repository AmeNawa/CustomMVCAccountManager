namespace MvcTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 1));
            AlterColumn("dbo.Users", "Surname", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
        }
    }
}
