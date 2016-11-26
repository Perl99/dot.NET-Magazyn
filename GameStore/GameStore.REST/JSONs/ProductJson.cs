using System.Runtime.Serialization;
using GameStore.Domain.Entities;

namespace GameStore.REST.JSONs
{
    [DataContract]
    public class ProductJson
    {
        [DataMember(Name = "Id", IsRequired = true)]
        public int Id { get; set; }

        [DataMember(Name = "Name", IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Name = "Description", IsRequired = true)]
        public string Description { get; set; }

        [DataMember(Name = "Price", IsRequired = true)]
        public decimal Price { get; set; }

        [DataMember(Name = "Category", IsRequired = true)]
        public string Category { get; set; }

        [DataMember(Name = "OwnerLogin", IsRequired = false)]
        public string OwnerLogin { get; set; }

        public ProductJson(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Category = product.Category;
            Price = product.Price;
            OwnerLogin = product.OwnerLogin;
        }

        public Product ToProduct() => new Product
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Category = Category,
            Price = Price,
            OwnerLogin = OwnerLogin
        };
    }
}