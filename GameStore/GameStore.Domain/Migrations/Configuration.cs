using System;
using System.Data.Entity.Migrations;
using System.Web;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "GameStore.Domain.Concrete.EFDbContext";

            if (HttpContext.Current == null)
            {
                // dla migracji
                string dbPath =
                    System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Databases"));
                AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);
            }
        }

        protected override void Seed(EFDbContext context)
        {
            context.DeleteAll<Offer>();
            context.DeleteAll<Auction>();
            context.DeleteAll<Product>();
            context.DeleteAll<User>();

            var user = new User
            {
                Name = "Szara",
                Surname = "Eminencja",
                Login = "admin",
                Password = "admin",
                Type = false//UserType.Client
            };

            context.Users.Add(user);

            var product = new Product
            {
                Name = "Produkt 1",
                Description = "Opis produktu 1",
                Category = "Bezcenne",
                OwnerLogin = "admin",
                Price = Convert.ToDecimal(999.99)
            };

            context.Users.Add(user);
            context.Products.Add(product);

            base.Seed(context);
        }
    }
}
