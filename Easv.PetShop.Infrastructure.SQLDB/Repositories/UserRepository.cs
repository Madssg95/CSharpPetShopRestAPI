using System.Collections.Generic;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Infrastructure.SQLDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly PetShopContext _ctx;

        public UserRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        
        public User CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> ReadUsers()
        {
            return _ctx.Users;
        }

        public User ReadByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public User DeleteUser(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}