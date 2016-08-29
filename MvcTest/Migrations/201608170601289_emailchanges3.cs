namespace MvcTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailchanges3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RePassword", c => c.String());
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "User_Id", c => c.Int());
            AlterColumn("dbo.Users", "Email", c => c.String());
            CreateIndex("dbo.Users", "User_Id");
            AddForeignKey("dbo.Users", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_Id" });
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Users", "User_Id");
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "RePassword");
        }
    }
}
