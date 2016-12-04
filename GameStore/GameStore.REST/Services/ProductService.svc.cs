using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.REST.JSONs;
using Authorization = GameStore.REST.Security.Authorization;

namespace GameStore.REST.Services
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;
        private IUserRepository userRepository;
        private Authorization authorization;

        public ProductService(IProductRepository productRepository, IUserRepository userRepository, Authorization authorization)
        {
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.authorization = authorization;
        }

        public ProductJson Get(string id)
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            Product product = productRepository.Find(int.Parse(id));

            if (product == null)
            {
                throw new WebFaultException(HttpStatusCode.NotFound);
            }

            return new ProductJson(product);
        }

        public List<ProductJson> List()
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
            return productRepository.Products.Select(product => new ProductJson(product)).ToList();
        }

        public void Save(ProductJson json)
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
            // TODO: walidacja

            Product product = json.ToProduct();
            product.OwnerLogin = userRepository.Find(authorization.UserId).Login;

            productRepository.Save(product);
        }
    }
}
