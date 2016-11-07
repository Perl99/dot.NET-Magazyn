using System;

namespace GameStore.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public UserType Type { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}