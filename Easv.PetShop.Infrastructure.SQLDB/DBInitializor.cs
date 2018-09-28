using System;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Infrastructure.SQLDB
{
    public class DBInitializor
    {
        public static void SeedDB(PetShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            
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
            ctx.SaveChanges();
            
            
        }
    }
}