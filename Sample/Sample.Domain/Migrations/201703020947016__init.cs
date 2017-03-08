namespace Sample.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Duration = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        RollNumber = c.String(nullable: false, maxLength: 150),
                        CourseId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        Username = c.String(nullable: false, maxLength: 8),
                        Password = c.String(nullable: false, maxLength: 8),
                        EmailId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Login", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "CourseId", "dbo.Course");
            DropIndex("dbo.Login", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "CourseId" });
            DropTable("dbo.Login");
            DropTable("dbo.Student");
            DropTable("dbo.Course");
        }
    }
}
