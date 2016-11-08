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
        public int Id { get; set; }

        [DisplayName("Produkty")]
        public ICollection<Product> Products { get; set; } = new List<Product>();

        [Required]
        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Właściciel")]
        public User Owner { get; set; }

        [DisplayName("Oferty")]
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();

        [Display(Name = "Data utworzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
    }
}