using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.REST
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Get(string id)
        {
            return productRepository.Find(Int32.Parse(id));
        }

        public List<Product> List()
        {
            return productRepository.Products.ToList();
        }
    }
}
