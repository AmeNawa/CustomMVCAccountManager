namespace MvcTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userchange2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String(maxLength: 1));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 1));
        }
    }
}
