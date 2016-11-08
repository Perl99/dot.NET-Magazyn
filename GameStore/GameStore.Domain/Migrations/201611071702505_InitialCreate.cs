namespace GameStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    Type = c.Boolean(),
                    Name = c.String(),
                    Surname = c.String(),
                    Login = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.UserId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Users");
        }
    }
}
