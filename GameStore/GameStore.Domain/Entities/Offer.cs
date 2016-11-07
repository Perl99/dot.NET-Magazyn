namespace GameStore.Domain.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public User Owner { get; set; }
        public decimal Price { get; set; }

        // States if the offer was accepted by the client
        public bool Accepted { get; set; }
    }
}