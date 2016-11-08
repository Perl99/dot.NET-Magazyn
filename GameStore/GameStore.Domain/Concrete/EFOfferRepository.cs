using System.Collections.Generic;
using System.Data.Entity;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Concrete
{
    public class EFOfferRepository : IOfferRepository
    {
        private EFDbContext context;

        public EFOfferRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Offer> Offers
        {
            get
            {
                return context.Offers;
            }
        }

        public Offer Find(int? id)
        {
            return context.Offers.Find(id);
        }

        public void Add(Offer offer)
        {
            context.Offers.Add(offer);
            context.SaveChanges();
        }

        public void Save(Offer offer)
        {
            context.Entry(offer).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}