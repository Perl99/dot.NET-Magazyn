using System.ComponentModel;

namespace GameStore.Domain.Entities
{
    public class Product
    {
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