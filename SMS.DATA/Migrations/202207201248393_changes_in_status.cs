namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes_in_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Status");
        }
    }
}
