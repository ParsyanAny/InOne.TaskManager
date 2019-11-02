namespace InOne.TaskManager.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RegistrationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "RegistrationTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RegistrationTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "RegistrationDate");
        }
    }
}
