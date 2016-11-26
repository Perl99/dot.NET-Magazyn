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
            Product product = productRepository.Find(int.Parse(id));

            if (product == null)
            {
                throw new WebFaultException(HttpStatusCode.NotFound);
            }

            return new ProductJson(product);
        }

        public List<ProductJson> List()
        {
            return productRepository.Products.Select(product => new ProductJson(product)).ToList();
        }

        public void Save(ProductJson json)
        {
            // TODO: walidacja

            Product product = json.ToProduct();
            product.OwnerLogin = "TMP"; // TODO: faktyczny login z sesji użytkownika

            productRepository.Save(product);
        }
    }
}
