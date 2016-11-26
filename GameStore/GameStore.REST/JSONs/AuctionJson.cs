using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.REST.JSONs
{
    [DataContract]
    public class AuctionJson
    {
        [DataMember(Name = "Id", IsRequired = true)]
        public int Id { get; set; }

        [DataMember(Name = "Products", IsRequired = true)]
        public List<ProductJson> Products { get; set; }

        [DataMember(Name = "Description", IsRequired = true)]
        public string Description { get; set; }

        [DataMember(Name = "Owner", IsRequired = true)]
        public UserJson Owner { get; set; }

        [DataMember(Name = "Offers", IsRequired = true)]
        public List<OfferJson> Offers { get; set; }

        [DataMember(Name = "CreationDate", IsRequired = true)]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public AuctionJson(Auction auction)
        {
            Id = auction.Id;
            Products = auction.Products.Select(product => new ProductJson(product)).ToList();
            Description = auction.Description;
            Owner = new UserJson(auction.Owner);
            Offers = auction.Offers.Select(offer => new OfferJson(offer)).ToList();
            CreationDate = auction.CreationDate;
        }

        public Auction ToAuction(IAuctionRepository auctionRepository) => new Auction
        {
            Id = Id,
            Products = Products.Select(productJson => productJson.ToProduct()).ToList(),
            Description = Description,
            Owner = Owner.ToUser(),
            Offers = Offers.Select(offerJson => offerJson.ToOffer(auctionRepository)).ToList(),
            CreationDate = CreationDate
        };
    }
}