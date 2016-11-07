using System.Collections.Generic;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Abstract
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> Offers { get; }
        Offer Find(int? id);
        void Add(Offer offer);
        void Save(Offer offer);
    }
}
