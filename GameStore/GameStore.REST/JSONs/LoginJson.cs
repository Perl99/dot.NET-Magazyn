using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GameStore.REST.JSONs
{
    public class LoginJson
    {
        [DataMember(Name = "Login", IsRequired = true)]
        public string Login { get; set; }

        [DataMember(Name = "Password", IsRequired = true)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}