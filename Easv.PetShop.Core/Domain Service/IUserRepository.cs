using System;
using System.Collections.Generic;
using System.Text;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Application_Service.Impl
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        User Add(User user);
        User Edit(User user);
        User Remove(long id);
    }
}