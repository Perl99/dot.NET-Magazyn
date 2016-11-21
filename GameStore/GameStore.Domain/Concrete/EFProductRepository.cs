using System.Collections.Generic;
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

        public void Save(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.Description = product.Description;
                }
            }
            context.SaveChanges();
        }
    }
}