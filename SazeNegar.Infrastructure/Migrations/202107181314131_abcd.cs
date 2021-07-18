namespace SpadCompanyPanel.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abcd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cars", name: "BrandId", newName: "Brand_Id");
            RenameIndex(table: "dbo.Cars", name: "IX_BrandId", newName: "IX_Brand_Id");
            DropColumn("dbo.Brands", "BrandId");
            DropColumn("dbo.CarModels", "BrandId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarModels", "BrandId", c => c.Int(nullable: false));
            AddColumn("dbo.Brands", "BrandId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Cars", name: "IX_Brand_Id", newName: "IX_BrandId");
            RenameColumn(table: "dbo.Cars", name: "Brand_Id", newName: "BrandId");
        }
    }
}
