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

        public void Add(Auction auction)
        {
            context.Auctions.Add(auction);
            context.SaveChanges();
        }

        public void Save(Auction auction)
        {
            context.Entry(auction).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}