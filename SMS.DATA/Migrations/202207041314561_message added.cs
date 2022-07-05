namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messageadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "Firstname", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "Lastname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Lastname", c => c.String());
            AlterColumn("dbo.Student", "Firstname", c => c.String());
        }
    }
}
