using Microsoft.EntityFrameworkCore;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easv.PetShop.Core.Application_Service.Impl;
using Easv.PetShop.Infrastructure.SQLDB;

namespace Easv.PetShop.Infrastructure.SQLDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetShopContext db;

        public UserRepository(PetShopContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User Get(long id)
        {
            return db.Users.FirstOrDefault(b => b.Id == id);
        }

        public User Add(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public User Edit(User entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }

        public User Remove(long id)
        {
            var item = db.Users.FirstOrDefault(b => b.Id == id);
            db.Users.Remove(item);
            db.SaveChanges();
            return item;
        }
    }
}