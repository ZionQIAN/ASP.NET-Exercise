namespace FIT5032Assignment1_ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLoginedCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoginedCourses", "StudentId", "dbo.Students");
            DropIndex("dbo.LoginedCourses", new[] { "StudentId" });
            AddColumn("dbo.LoginedCourses", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.LoginedCourses", "ApplicationUserId");
            AddForeignKey("dbo.LoginedCourses", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.LoginedCourses", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoginedCourses", "StudentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.LoginedCourses", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.LoginedCourses", new[] { "ApplicationUserId" });
            DropColumn("dbo.LoginedCourses", "ApplicationUserId");
            CreateIndex("dbo.LoginedCourses", "StudentId");
            AddForeignKey("dbo.LoginedCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
