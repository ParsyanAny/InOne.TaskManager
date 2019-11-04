namespace InOne.TaskManager.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Location = c.String(nullable: false, maxLength: 200),
                        CreateDate = c.DateTime(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorId = c.Int(nullable: false),
                        AssignedId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Deleted = c.Boolean(nullable: false),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: false)
                .Index(t => t.CreatorId)
                .Index(t => t.AssignedId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 75),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "AssignedId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "AssignedId" });
            DropIndex("dbo.Tasks", new[] { "CreatorId" });
            DropIndex("dbo.Attachments", new[] { "TaskId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Attachments");
        }
    }
}
