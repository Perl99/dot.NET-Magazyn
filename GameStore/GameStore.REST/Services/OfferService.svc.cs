using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.REST.JSONs;

namespace GameStore.REST.Services
{
    public class OfferService : IOfferService
    {
        private IOfferRepository offerRepository;
        private IAuctionRepository auctionRepository;
        private IUserRepository userRepository;

        public OfferService(IOfferRepository offerRepository, IAuctionRepository auctionRepository, IUserRepository userRepository)
        {
            this.offerRepository = offerRepository;
            this.auctionRepository = auctionRepository;
            this.userRepository = userRepository;
        }

        public OfferJson Get(string id)
        {
            Offer offer = offerRepository.Find(int.Parse(id));

            if (offer == null)
            {
                throw new WebFaultException(HttpStatusCode.NotFound);
            }

            return new OfferJson(offer);
        }

        public List<OfferJson> List(string auctionId) => auctionRepository.Find(int.Parse(auctionId)).Offers.Select(offer => new OfferJson(offer)).ToList();

        public void Save(string auctionId, OfferJson json)
        {
            // TODO: walidacja

            Offer offer = json.ToOffer(auctionRepository);
            offer.Owner = userRepository.Users.FirstOrDefault(); // TODO: faktyczny user z sesji

            offerRepository.Save(offer);
        }

        public void Accept(string auctionId, string id)
        {
            Auction auction = auctionRepository.Find(int.Parse(auctionId));

            if (auction == null)
            {
                throw new WebFaultException(HttpStatusCode.NotFound);
            }

            foreach (var offer in auction.Offers)
            {
                offer.Accepted = (offer.Id == int.Parse(id));
                offerRepository.Save(offer);
            }
        }
    }
}
