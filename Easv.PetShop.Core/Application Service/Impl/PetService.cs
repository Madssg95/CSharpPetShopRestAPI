﻿using System;
using System.Collections.Generic;
using System.Linq;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Application_Service.Impl
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Pet AddPet(Pet pet)
        {
            if (pet.Name.Length < 2)
            {
                throw new Exception("The name must at least have two characters.");
            }

            if (pet.Type == null || pet.Color  == null)
            {
                throw new Exception("You are not allowed to enter empty credentials.");
            }

            if (pet.Price < 0)
            {
                throw new Exception("The pet's price can not be lower than 0.");
            }
            _petRepo.CreatePet(pet);
            return pet;
        }

        public Pet NewPet(string name, string type, DateTime birthday, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            var newPet = new Pet()
            {
                Name = name,
                Type = type,
                Birthday = birthday,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return newPet;
        }

        public Pet GetPetById(int id)
        {
            return _petRepo.ReadByID(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

        public List<Pet> SearchByType(string type)
        {
            var pets = _petRepo.ReadPets().ToList();
            var matchingPets = pets.Where(pet => pet.Type.ToLower().Contains(type));
            return matchingPets.ToList();
        }

        public List<Pet> Get5CheapestPets()
        {
            var listCheapest = _petRepo.ReadPets();
            listCheapest = listCheapest.OrderBy(pet => pet.Price).Take(5);
            return listCheapest.ToList();
        }

        public List<Pet> SortByPrice()
        {
            var sortedByPrice = _petRepo.ReadPets();
            sortedByPrice = sortedByPrice.OrderBy(pet => pet.Price);
            return sortedByPrice.ToList();
        }

        public Pet UpdatePet(Pet pet)
        {
            var changedPet = _petRepo.ReadByID(pet.Id);
            changedPet.Name = pet.Name;
            changedPet.Type = pet.Type;
            changedPet.Birthday = pet.Birthday;
            changedPet.SoldDate = pet.SoldDate;
            changedPet.Color = pet.Color;
            changedPet.PreviousOwner = pet.PreviousOwner;
            changedPet.Price = pet.Price;
            _petRepo.UpdatePet(changedPet);
            return changedPet;
            
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.DeletePet(id);

        }
    }
}
