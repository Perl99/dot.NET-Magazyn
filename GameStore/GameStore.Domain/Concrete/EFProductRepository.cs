using System.Collections.Generic;
using System.Data.Entity;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context;

        public EFProductRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }

        public Product Find(int? id)
        {
            return context.Products.Find(id);
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Save(Product product)
        {
            Product dbEntry = context.Products.Find(product.Id);
            if(dbEntry != null)
            {
                dbEntry.Name = product.Name;
                dbEntry.Price = product.Price;
                dbEntry.Category = product.Category;
                dbEntry.Description = product.Description;
            }
            context.SaveChanges();
        }
    }
}