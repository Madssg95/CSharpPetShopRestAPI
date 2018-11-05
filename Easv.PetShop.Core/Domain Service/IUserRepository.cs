using System.Collections.Generic;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Domain_Service
{
    public interface IUserRepository
    {
        //Create
        User CreateUser(User user);

        //Read
        IEnumerable<User> ReadUsers();
        User ReadByID(int id);

        //Update
        User UpdateUser(User user);

        //Delete
        User DeleteUser(int id);
    }
}