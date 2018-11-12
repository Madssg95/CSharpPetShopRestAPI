using System;
using System.Collections.Generic;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Infrastructure.SQLDB
{
    public class DBInitializor
    {
        public static void SeedDB(PetShopContext ctx)
        {
            
            //ctx.Database.EnsureDeleted();
            //ctx.Database.EnsureCreated();
            
            var owner1 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Karl",
                LastName = "Karlsen",
                Address = "Karlvej 11",
                PhoneNumber = 019282828
            }).Entity;
            
            var owner2 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Ole",
                LastName = "Olesen",
                Address = "Olevej 22",
                PhoneNumber = 019545454
            }).Entity;

            var color1 = ctx.Colors.Add(new Color()
            {
                PetColor = "Black"
            }).Entity;
            
            var color2 = ctx.Colors.Add(new Color()
            {
                PetColor = "White"
            }).Entity;
            
            var pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "Vovse",
                Type = "Dog",
                Birthday = DateTime.Now.AddMonths(-20),
                SoldDate = DateTime.Now.AddMonths(-5),
                Color = color1,
                Owner = owner1,
                Price = 100
            }).Entity;
            
            var pet2 = ctx.Pets.Add(new Pet()
            {
                Name = "Misser",
                Type = "Cat",
                Birthday = DateTime.Now.AddMonths(-30),
                SoldDate = DateTime.Now.AddMonths(-2),
                Color = color2,
                Owner = owner2,
                Price = 200
            }).Entity;
            
            
            
            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.Users.AddRange(users);
            ctx.SaveChanges();

        }

        
        
        
        // This method computes a hashed and salted password using the HMACSHA512 algorithm.
        // The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using 
        // the SHA512 hash function. When instantiated with the parameterless constructor (as
        // here) a randomly Key is generated. This key is used as a password salt.

        // The computation is performed as shown below:
        //   passwordHash = SHA512(password + Key)

        // A password salt randomizes the password hash so that two identical passwords will
        // have significantly different hash values. This protects against sophisticated attempts
        // to guess passwords, such as a rainbow table attack.
        // The password hash is 512 bits (=64 bytes) long.
        // The password salt is 1024 bits (=128 bytes) long.
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
    
}