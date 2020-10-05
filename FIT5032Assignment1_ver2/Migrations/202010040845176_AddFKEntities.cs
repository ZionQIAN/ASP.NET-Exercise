namespace FIT5032Assignment1_ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseTime = c.DateTime(nullable: false),
                        Address = c.String(),
                        CourseId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.LikeCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.LoginedCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginedCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.LoginedCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.LikeCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.LikeCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.CourseEvents", "CourseId", "dbo.Courses");
            DropIndex("dbo.LoginedCourses", new[] { "StudentId" });
            DropIndex("dbo.LoginedCourses", new[] { "CourseId" });
            DropIndex("dbo.LikeCourses", new[] { "StudentId" });
            DropIndex("dbo.LikeCourses", new[] { "CourseId" });
            DropIndex("dbo.CourseEvents", new[] { "EventId" });
            DropIndex("dbo.CourseEvents", new[] { "CourseId" });
            DropTable("dbo.LoginedCourses");
            DropTable("dbo.LikeCourses");
            DropTable("dbo.CourseEvents");
        }
    }
}
