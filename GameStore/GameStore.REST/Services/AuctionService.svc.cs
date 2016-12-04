using System;
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
    public class AuctionService : IAuctionService
    {
        private IAuctionRepository auctionRepository;
        private IUserRepository userRepository;
        private IProductRepository productRepository;
        private Authorization authorization;

        public AuctionService(IAuctionRepository auctionRepository, IUserRepository userRepository, IProductRepository productRepository, Authorization authorization)
        {
            this.auctionRepository = auctionRepository;
            this.userRepository = userRepository;
            this.productRepository = productRepository;
            this.authorization = authorization;
        }

        public AuctionJson Get(string id)
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            Auction auction = auctionRepository.Find(int.Parse(id));

            if (auction == null)
            {
                throw new WebFaultException(HttpStatusCode.NotFound);
            }

            return new AuctionJson(auction);
        }

        public List<AuctionJson> List()
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            return auctionRepository.Auctions.Select(auction => new AuctionJson(auction)).ToList();
        }

        public void Save(AuctionJson json)
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
            // TODO: walidacja

            Auction auction = json.ToAuction(auctionRepository, true, true);
            auction.Owner = userRepository.Find(authorization.UserId);
            auction.CreationDate = DateTime.Now;

            foreach (var productsIds in json.ProductsIds)
            {
                Product product = productRepository.Find(productsIds);

                if (product == null)
                {
                    throw new WebFaultException(HttpStatusCode.NotFound);
                }

                auction.Products.Add(product);
            }

            auctionRepository.Save(auction);
        }
    }
}
