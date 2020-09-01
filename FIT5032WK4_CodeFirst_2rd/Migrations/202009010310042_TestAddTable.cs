namespace FIT5032WK4_CodeFirst_2rd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAddTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.FirstName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
