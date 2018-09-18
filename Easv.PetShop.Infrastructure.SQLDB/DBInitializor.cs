using System;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Infrastructure.SQLDB
{
    public class DBInitializor
    {
        public static void SeedDB(PetShopContext ctx)
        {
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
            
            
            var pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "Vovse",
                Type = "Dog",
                Birthday = DateTime.Now.AddMonths(-20),
                SoldDate = DateTime.Now.AddMonths(-5),
                Color = "black",
                PreviousOwner = owner1
            });
            
            var pet2 = ctx.Pets.Add(new Pet()
            {
                Name = "Misser",
                Type = "Cat",
                Birthday = DateTime.Now.AddMonths(-30),
                SoldDate = DateTime.Now.AddMonths(-2),
                Color = "white",
                PreviousOwner = owner2
            });
            ctx.SaveChanges();
        }
    }
}