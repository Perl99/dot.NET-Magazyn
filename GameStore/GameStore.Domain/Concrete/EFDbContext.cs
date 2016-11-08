﻿using GameStore.Domain.Entities;
using System.Data.Entity;
using GameStore.Domain.Migrations;

namespace GameStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {

        public EFDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Configuration>());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        
    }
}