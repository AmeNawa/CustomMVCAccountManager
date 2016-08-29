namespace MvcTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filetablerename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Files", newName: "UserFiles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserFiles", newName: "Files");
        }
    }
}
