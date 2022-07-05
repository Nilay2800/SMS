namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Guid(nullable: false),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Standard = c.Int(nullable: false),
                        Email = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
        }
    }
}
