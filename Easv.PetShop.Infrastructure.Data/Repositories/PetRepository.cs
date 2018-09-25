using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        public PetRepository()
        {
            if (FakeDB.ListOfPets.Any()) return;

            var pet1 = new Pet()
            {
                Id = FakeDB.PetId++,
                Name = "Vovse",
                Type = "Dog",
                Birthday = DateTime.Now.AddMonths(-6),
                SoldDate = DateTime.Now.AddMonths(-3),
                Color = "Black",
                Owner = new Owner(){Id = 1},
                Price = 100
            };
            
            var pet2 = new Pet()
            {
                Id = FakeDB.PetId++,
                Name = "Misse",
                Type = "Cat",
                Birthday = DateTime.Now.AddMonths(-10),
                SoldDate = DateTime.Now.AddMonths(-5),
                Color = "White",
                Owner = new Owner(){Id = 2},
                Price = 500
            };

            var pets = FakeDB.ListOfPets.ToList();
            pets.Add(pet1);
            pets.Add(pet2);
            FakeDB.ListOfPets = pets;
        }

        public Pet CreatePet(Pet pet)
        {
            pet.Id = FakeDB.PetId++;
            var pets = FakeDB.ListOfPets.ToList();
            pets.Add(pet);
            FakeDB.ListOfPets = pets;
            return pet;
        }

        public Pet DeletePet(int id)
        {
            var pets = FakeDB.ListOfPets.ToList();
            var petToDelete = pets.FirstOrDefault(pet => pet.Id == id);
            pets.Remove(petToDelete);
            FakeDB.ListOfPets = pets;
            return petToDelete;
        }

        public Pet ReadByID(int id)
        {
            var pets = FakeDB.ListOfPets.ToList();
            var matchingPet = pets.FirstOrDefault(pet => pet.Id == id);
            return matchingPet;
        }

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            return FakeDB.ListOfPets;
        }

        public Pet UpdatePet(Pet updatePet)
        {
            var pets = ReadPets(null);
            var pet = pets.FirstOrDefault(pet1 => pet1.Id == updatePet.Id);
            FakeDB.ListOfPets = pets;
            return pet;
        }
    }
}
