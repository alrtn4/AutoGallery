namespace SpadCompanyPanel.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "CarId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CarId", c => c.Int(nullable: false));
        }
    }
}
