namespace FIT5032Assignment1_ver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeThreeSampleEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Image", c => c.String());
            AddColumn("dbo.Events", "Color", c => c.String());
            AddColumn("dbo.Students", "PhoneNo", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EventName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Students", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Password", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Events", "EventName", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
            DropColumn("dbo.Students", "PhoneNo");
            DropColumn("dbo.Events", "Color");
            DropColumn("dbo.Courses", "Image");
        }
    }
}
