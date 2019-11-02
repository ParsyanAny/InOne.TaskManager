namespace InOne.TaskManager.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigarion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenderType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorId = c.Int(nullable: false),
                        AssignedId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Deleted = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: false)
                .ForeignKey("dbo.StatusCodes", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CreatorId)
                .Index(t => t.AssignedId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 75),
                        GenderId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        RegistrationTime = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "StatusId", "dbo.StatusCodes");
            DropForeignKey("dbo.Tasks", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "AssignedId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "StatusId" });
            DropIndex("dbo.Tasks", new[] { "AssignedId" });
            DropIndex("dbo.Tasks", new[] { "CreatorId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.StatusCodes");
            DropTable("dbo.Genders");
            DropTable("dbo.Attachments");
        }
    }
}
