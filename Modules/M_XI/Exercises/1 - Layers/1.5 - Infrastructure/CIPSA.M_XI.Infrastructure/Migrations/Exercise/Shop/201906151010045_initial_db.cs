namespace CIPSA.M_XI.Infrastructure.Migrations.Exercise.Shop
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        IsAdult = c.Boolean(nullable: false),
                        IsRented = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rental",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.ClientId })
                .ForeignKey("dbo.Article", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NIF = c.String(nullable: false, maxLength: 9),
                        Name = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Birthday = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NIF, unique: true, name: "IX_Client_NIF");
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Platform = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Article", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Device = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Article", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "Id", "dbo.Article");
            DropForeignKey("dbo.Game", "Id", "dbo.Article");
            DropForeignKey("dbo.Rental", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Rental", "ArticleId", "dbo.Article");
            DropIndex("dbo.Movie", new[] { "Id" });
            DropIndex("dbo.Game", new[] { "Id" });
            DropIndex("dbo.Client", "IX_Client_NIF");
            DropIndex("dbo.Rental", new[] { "ClientId" });
            DropIndex("dbo.Rental", new[] { "ArticleId" });
            DropTable("dbo.Movie");
            DropTable("dbo.Game");
            DropTable("dbo.Client");
            DropTable("dbo.Rental");
            DropTable("dbo.Article");
        }
    }
}
