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

        [DataMember(Name = "Products", IsRequired = false)]
        public List<ProductJson> Products { get; set; }

        [DataMember(Name = "ProductsIds", IsRequired = true)]
        public List<int> ProductsIds { get; set; }

        [DataMember(Name = "Description", IsRequired = true)]
        public string Description { get; set; }

        [DataMember(Name = "Owner", IsRequired = true)]
        public UserJson Owner { get; set; }

        [DataMember(Name = "Offers", IsRequired = false)]
        public List<OfferJson> Offers { get; set; }

        [DataMember(Name = "CreationDate", IsRequired = false)]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public AuctionJson(Auction auction)
        {
            Id = auction.Id;
            Products = auction.Products.Select(product => new ProductJson(product)).ToList();
            Description = auction.Description;

            Owner = new UserJson(auction.Owner) {Password = null};

            Offers = auction.Offers.Select(offer => new OfferJson(offer)).ToList();
            CreationDate = auction.CreationDate;
        }

        public Auction ToAuction(IAuctionRepository auctionRepository, bool offersFromDb = true, bool productsFromDb = true)
        {
            List<Offer> offerList;

            if (!offersFromDb) offerList = Offers.Select(offerJson => offerJson.ToOffer(auctionRepository)).ToList();
            else offerList = auctionRepository.Find(Id).Offers.ToList();

            List<Product> productList;

            if (!productsFromDb) productList = Products.Select(productJson => productJson.ToProduct()).ToList();
            else productList = auctionRepository.Find(Id).Products.ToList();

            return new Auction
            {
                Id = Id,
                Products = productList,
                Description = Description,
                Owner = Owner.ToUser(),
                Offers = offerList,
                CreationDate = CreationDate
            };
        }
    }
}