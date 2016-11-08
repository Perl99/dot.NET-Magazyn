namespace GameStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Accepted = c.Boolean(nullable: false),
                        Auction_Id = c.Int(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Auction_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductAuctions",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Auction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Auction_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Auction_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductAuctions", "Auction_Id", "dbo.Auctions");
            DropForeignKey("dbo.ProductAuctions", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Auctions", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Offers", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Offers", "Auction_Id", "dbo.Auctions");
            DropIndex("dbo.ProductAuctions", new[] { "Auction_Id" });
            DropIndex("dbo.ProductAuctions", new[] { "Product_Id" });
            DropIndex("dbo.Offers", new[] { "Owner_Id" });
            DropIndex("dbo.Offers", new[] { "Auction_Id" });
            DropIndex("dbo.Auctions", new[] { "Owner_Id" });
            DropTable("dbo.ProductAuctions");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Offers");
            DropTable("dbo.Auctions");
        }
    }
}
