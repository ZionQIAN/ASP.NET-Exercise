namespace FIT5032WK4_CodeFirst_2rd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            AddColumn("dbo.Students", "Uint_Name", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "Uint_Name");
            AddForeignKey("dbo.Students", "Uint_Name", "dbo.Units", "Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Uint_Name", "dbo.Units");
            DropIndex("dbo.Students", new[] { "Uint_Name" });
            DropColumn("dbo.Students", "Uint_Name");
            DropTable("dbo.Units");
        }
    }
}
