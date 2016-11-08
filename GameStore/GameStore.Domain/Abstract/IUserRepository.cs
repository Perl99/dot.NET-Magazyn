using System.Collections.Generic;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        User Find(string login, string password);
        void Add(User user);
        void Save(User user);
    }
}

