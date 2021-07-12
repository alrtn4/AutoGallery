namespace SpadCompanyPanel.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Title", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Cars", "Price", c => c.String());
            AddColumn("dbo.Cars", "Gear", c => c.String());
            AddColumn("dbo.Cars", "Sunroof", c => c.String());
            AddColumn("dbo.Cars", "Navigation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Navigation");
            DropColumn("dbo.Cars", "Sunroof");
            DropColumn("dbo.Cars", "Gear");
            DropColumn("dbo.Cars", "Price");
            DropColumn("dbo.Cars", "Title");
        }
    }
}
