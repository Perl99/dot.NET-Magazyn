using System.Runtime.Serialization;

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

        [DataMember(Name = "Właściciel", IsRequired = false)]
        public string OwnerLogin { get; set; }
    }
}