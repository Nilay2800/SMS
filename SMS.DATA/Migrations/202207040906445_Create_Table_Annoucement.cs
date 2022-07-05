namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Annoucement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annoucements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnnoucementDetail = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Annoucements");
        }
    }
}
