namespace FIT5032Assignment1_ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Courses", "Discription", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EventName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EventName", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Discription", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
        }
    }
}
