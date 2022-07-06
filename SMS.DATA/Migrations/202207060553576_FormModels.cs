namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NavigateURL = c.String(),
                        FormAcessCode = c.String(),
                        DisplayOrder = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDisplayMenu = c.Boolean(nullable: false),
                        ParentForm = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FormModel");
        }
    }
}
