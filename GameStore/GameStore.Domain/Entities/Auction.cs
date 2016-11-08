using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Domain.Entities
{
    public class Auction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuctionId { get; set; }

        [DisplayName("Produkty")]
        public IEnumerable<Product> Products { get; set; }

        [DisplayName("Właściciel")]
        public User Owner { get; set; }

        [DisplayName("Oferty")]
        public IEnumerable<Offer> Offers { get; set; }

        [Display(Name = "Data utworzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
    }
}