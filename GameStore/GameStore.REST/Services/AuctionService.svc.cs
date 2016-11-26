using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.REST.JSONs;

namespace GameStore.REST.Services
{
    public class AuctionService : IAuctionService
    {
        private IAuctionRepository auctionRepository;
        private IUserRepository userRepository;
        private IProductRepository productRepository;

        public AuctionService(IAuctionRepository auctionRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            this.auctionRepository = auctionRepository;
            this.userRepository = userRepository;
            this.productRepository = productRepository;
        }

        public AuctionJson Get(string id)
        {
            Auction auction = auctionRepository.Find(int.Parse(id));

            if (auction == null)
            {
                throw new WebFaultException(HttpStatusCode.NotFound);
            }

            return new AuctionJson(auction);
        }

        public List<AuctionJson> List() => auctionRepository.Auctions.Select(auction => new AuctionJson(auction)).ToList();

        public void Save(AuctionJson json)
        {
            // TODO: walidacja

            Auction auction = json.ToAuction(auctionRepository, true, true);
            auction.Owner = userRepository.Users.FirstOrDefault(); // TODO: faktyczny user z sesji
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
