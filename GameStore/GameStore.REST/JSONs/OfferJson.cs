using System.Runtime.Serialization;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.REST.JSONs
{
    [DataContract]
    public class OfferJson
    {
        [DataMember(Name = "Id", IsRequired = true)]
        public int Id { get; set; }

        [DataMember(Name = "Owner", IsRequired = false)]
        public UserJson Owner { get; set; }

        [DataMember(Name = "Price", IsRequired = true)]
        public decimal Price { get; set; }

        [DataMember(Name = "Accepted", IsRequired = true)]
        public bool Accepted { get; set; }

        [DataMember(Name = "AuctionId", IsRequired = true)]
        public int AuctionId { get; set; }

        public OfferJson(Offer offer)
        {
            Id = offer.Id;
            Owner = new UserJson(offer.Owner);
            Price = offer.Price;
            Accepted = offer.Accepted;
            AuctionId = offer.Auction.Id;
        }

        public Offer ToOffer(IAuctionRepository auctionRepository) => new Offer
        {
            Id = Id,
            Owner = Owner.ToUser(),
            Price = Price,
            Accepted = Accepted,
            Auction = auctionRepository.Find(AuctionId)
        };
    }
}