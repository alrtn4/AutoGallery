namespace SpadCompanyPanel.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "carId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "carId");
        }
    }
}
