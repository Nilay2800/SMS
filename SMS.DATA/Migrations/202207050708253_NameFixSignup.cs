namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameFixSignup : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.Signups",
                c => new
                    {
                        Userid = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Userid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Signups");
           
        }
    }
}
