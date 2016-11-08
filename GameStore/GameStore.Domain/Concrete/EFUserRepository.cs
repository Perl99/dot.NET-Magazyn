using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context;

        public EFUserRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public User Find(int? id)
        {
            return context.Users.Find(id);
        }

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Save(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public User FindByLoginAndPassword(string login, string password)
        {
            return context.Users
                .FirstOrDefault(user => user.Login == login && user.Password == password);
        }
    }
}