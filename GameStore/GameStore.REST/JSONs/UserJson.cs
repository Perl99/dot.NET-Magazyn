using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GameStore.Domain.Entities;

namespace GameStore.REST.JSONs
{
    [DataContract]
    public class UserJson
    {
        [DataMember(Name = "Id", IsRequired = true)]
        public int Id { get; set; }

        [DataMember(Name = "Type", IsRequired = true)]
        public bool Type { get; set; }

        [DataMember(Name = "Imię", IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Name = "Nazwisko", IsRequired = true)]
        public string Surname { get; set; }

        [DataMember(Name = "Login", IsRequired = true)]
        public string Login { get; set; }

        [DataMember(Name = "Password", IsRequired = true)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserJson(User user)
        {
            Id = user.Id;
            Type = user.Type;
            Name = user.Name;
            Surname = user.Surname;
            Login = user.Login;
            Password = user.Password;
        }

        public User ToUser() => new User
        {
            Id = Id,
            Type = Type,
            Name = Name,
            Surname = Surname,
            Login = Login,
            Password = Password
        };
    }
}