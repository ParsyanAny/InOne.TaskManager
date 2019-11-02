namespace InOne.TaskManager.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.String());
            DropColumn("dbo.Users", "GenderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "GenderId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Gender");
        }
    }
}
