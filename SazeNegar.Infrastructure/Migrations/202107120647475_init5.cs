namespace SpadCompanyPanel.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Brand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .Index(t => t.Brand_Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false, maxLength: 100),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        CarModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarModels", t => t.CarModel_Id)
                .Index(t => t.CarModel_Id);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 100),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarModelCarClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarClass_Id = c.Int(),
                        CarModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarClasses", t => t.CarClass_Id)
                .ForeignKey("dbo.CarModels", t => t.CarModel_Id)
                .Index(t => t.CarClass_Id)
                .Index(t => t.CarModel_Id);
            
            CreateTable(
                "dbo.CarClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Carclass = c.String(nullable: false, maxLength: 100),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.CarModelCarClasses", "CarModel_Id", "dbo.CarModels");
            DropForeignKey("dbo.CarModelCarClasses", "CarClass_Id", "dbo.CarClasses");
            DropForeignKey("dbo.Brands", "CarModel_Id", "dbo.CarModels");
            DropIndex("dbo.CarModelCarClasses", new[] { "CarModel_Id" });
            DropIndex("dbo.CarModelCarClasses", new[] { "CarClass_Id" });
            DropIndex("dbo.Brands", new[] { "CarModel_Id" });
            DropIndex("dbo.Cars", new[] { "Brand_Id" });
            DropTable("dbo.CarClasses");
            DropTable("dbo.CarModelCarClasses");
            DropTable("dbo.CarModels");
            DropTable("dbo.Brands");
            DropTable("dbo.Cars");
        }
    }
}
