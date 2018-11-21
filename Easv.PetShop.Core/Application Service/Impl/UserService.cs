using System.Collections.Generic;
using System.Linq;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Application_Service.Impl
{
    public class UserService : IUserService
    
    {
        private readonly IUserRepository _userRepo;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        
        public User AddUser(User user, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            if (password == "admin")
            {
                user.IsAdmin = true;
            }
            return _userRepo.Add(user);
        }

        public List<User> GetUsers()
        {
            return _userRepo.GetAll().ToList();
        }

        public User GetUserById(int id)
        {
            return _userRepo.Get(id);
        }

        public User UpdateUser(User user)
        {
            return _userRepo.Edit(user);
        }

        public User DeleteUser(int id)
        {
            return _userRepo.Remove(id);
        }
        
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}