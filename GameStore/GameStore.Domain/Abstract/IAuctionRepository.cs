using System.Collections.Generic;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Abstract
{
    public interface IAuctionRepository
    {
        IEnumerable<Auction> Auctions { get; }
        Auction Find(int? id);
        void Save(Auction auction);
    }
}
