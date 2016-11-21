using System.Collections.Generic;
using System.Data.Entity;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Concrete
{
    public class EFAuctionRepository : IAuctionRepository
    {
        private EFDbContext context;

        public EFAuctionRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Auction> Auctions
        {
            get
            {
                return context.Auctions;
            }
        }

        public Auction Find(int? id)
        {
            return context.Auctions.Find(id);
        }

        public void Save(Auction auction)
        {
            if (auction.Id == 0)
            {
                context.Auctions.Add(auction);
            }
            else
            {
                Auction dbEntry = context.Auctions.Find(auction.Id);
                if (dbEntry != null)
                {
                    dbEntry.Offers = auction.Offers;
                }
            }
            context.SaveChanges();
        }
    }
}