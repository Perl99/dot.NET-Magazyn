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
    public class OfferService : IOfferService
    {
        private IOfferRepository offerRepository;
        private IAuctionRepository auctionRepository;
        private IUserRepository userRepository;
        private Authorization authorization;

        public OfferService(IOfferRepository offerRepository, IAuctionRepository auctionRepository, IUserRepository userRepository, Authorization authorization)
        {
            this.offerRepository = offerRepository;
            this.auctionRepository = auctionRepository;
            this.userRepository = userRepository;
            this.authorization = authorization;
        }

        public OfferJson Get(string id)
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            Offer offer = offerRepository.Find(int.Parse(id));

            if (offer == null)
            {
                throw new WebFaultException(HttpStatusCode.NotFound);
            }

            return new OfferJson(offer);
        }

        public List<OfferJson> List(string auctionId)
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            return auctionRepository.Find(int.Parse(auctionId)).Offers.Select(offer => new OfferJson(offer)).ToList();
        }

        public void Save(string auctionId, OfferJson json)
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
            // TODO: walidacja

            Offer offer = json.ToOffer(auctionRepository);
            offer.Owner = userRepository.Find(authorization.UserId);

            offerRepository.Save(offer);
        }

        public void Accept(string auctionId, string id)
        {
            if (!authorization.IsAuthorized())
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

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
