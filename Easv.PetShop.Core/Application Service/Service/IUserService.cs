using System.Collections.Generic;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Application_Service.Service
{
    public interface IUserService
    {
        //Create
        User AddUser(User user);
        //Owner NewOwner(string firstname, string lastname, string address, int phoneNumber);

        //Read
        List<User> GetUsers();
        User GetUserById(int id);

        //Update
        User UpdateUser(User user);

        //Delete
        User DeleteUser(int id);

    }
}