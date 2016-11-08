using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [DisplayName("Typ")]
        public UserType Type { get; set; }

        [DisplayName("Imię")]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        public string Surname { get; set; }

        [DisplayName("Login")]
        public string Login { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }
    }
}