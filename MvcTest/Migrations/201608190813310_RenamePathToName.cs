namespace MvcTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamePathToName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFiles", "Name", c => c.String());
            DropColumn("dbo.UserFiles", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserFiles", "Path", c => c.String());
            DropColumn("dbo.UserFiles", "Name");
        }
    }
}
