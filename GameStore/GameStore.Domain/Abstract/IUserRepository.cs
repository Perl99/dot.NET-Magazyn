using System.Collections.Generic;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        User Find(int? id);
        void Add(User user);
        void Save(User user);
        User FindByLoginAndPassword(string login, string password);
    }
}

