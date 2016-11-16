using System.Collections.Generic;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        Product Find(int? id);
        void Save(Product product);
    }
}
