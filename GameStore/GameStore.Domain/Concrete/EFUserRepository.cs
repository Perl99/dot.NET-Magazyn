using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public User Find(string login, string password)
        {
            try
            {
                return context.Users.Single(u => u.Login == login && u.Password == password);
            }
            catch (Exception)
            {
                return null;
            }
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
    }
}