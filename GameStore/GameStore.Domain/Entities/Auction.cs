using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Domain.Entities
{
    public class Auction
    {
        public int AuctionId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public User Owner { get; set; }
        public Offer Offer { get; set; }

        [Display(Name = "Creation date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
    }
}