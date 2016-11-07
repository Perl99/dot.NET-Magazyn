using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Cena")]
        public decimal Price { get; set; }

        [DisplayName("Kategoria")]
        public string Category { get; set; }
    }
}