namespace ProductApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Created", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Created", c => c.DateTime(nullable: false));
        }
    }
}
