using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.REST.JSONs;

namespace GameStore.REST.Services
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ProductJson Get(string id)
        {
            Product dBProductJson = productRepository.Find(int.Parse(id));

            if (dBProductJson == null)
            {
                throw new WebFaultException(HttpStatusCode.NotFound);
            }

            ProductJson productJson = new ProductJson();

            return productJson;
        }

        public List<ProductJson> List()
        {
            return productRepository.Products.Select(product => new ProductJson
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                OwnerLogin = product.OwnerLogin
            }).ToList();
        }

        public void Save(ProductJson json)
        {
            productRepository.Save(
                new Product
                {
                    Id = json.Id,
                    Name = json.Name,
                    Description = json.Description,
                    Category = json.Category,
                    Price = json.Price,
                    OwnerLogin = "TMP" // TODO: faktyczny login z sesji użytkownika
                    //OwnerLogin = json.OwnerLogin
                }
            );
        }
    }
}
