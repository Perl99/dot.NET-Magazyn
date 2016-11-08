using System;
using System.Data.Entity.Migrations;
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
        }

        protected override void Seed(EFDbContext context)
        {
            var user = new User
            {
                Name = "Szara",
                Surname = "Eminencja",
                Login = "admin",
                Password = "admin",
                Type = UserType.Client
            };

            context.Users.Add(user);

            var product = new Product
            {
                Name = "Produkt 1",
                Description = "Opis produktu 1",
                Category = "Fajowe",
                Price = Convert.ToDecimal(100.99)
            };

            context.Users.Add(user);
            context.Products.Add(product);

            base.Seed(context);
        }
    }
}
