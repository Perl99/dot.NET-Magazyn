using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Domain.Entities
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Właściciel")]
        public User Owner { get; set; }

        [DisplayName("Cena")]
        public decimal Price { get; set; }

        // States if the offer was accepted by the client
        [DisplayName("Zatwierdzona")]
        public bool Accepted { get; set; }

        public Auction Auction { get; set; }
    }
}