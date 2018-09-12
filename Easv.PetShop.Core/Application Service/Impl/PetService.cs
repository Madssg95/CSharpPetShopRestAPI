using System;
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
        readonly IOwnerRepository _ownerRepo;

        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepo = petRepository;
            _ownerRepo = ownerRepository;
        }

        public Pet AddPet(Pet pet)
        {
            if (pet.Name.Length < 2)
            {
                throw new Exception("The name must at least have two characters.");
            }

            if (pet.Type == null)
            {
                throw new Exception("Please enter a type.");
            }

            if (pet.Color == null)
            {
                throw new Exception("Please enter a color."); 
            }

            if (pet.Price < 0)
            {
                throw new Exception("The pet's price can not be lower than 0.");
            }

            if (pet.Birthday > DateTime.Today || pet.SoldDate > DateTime.Today)
            {
                throw new Exception("The date you have chosen is in the future.");
            }
            
            if (pet.Birthday > pet.SoldDate)
            {
                throw new Exception("The sold date has to be after the birthday.");
            }

            if (_petRepo.ReadByID(pet.PreviousOwner.Id) == null)
            {
                throw new Exception("Please enter a valid owner Id.");
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
            if (id < 1 || _petRepo.ReadByID(id) == null)
            {
                throw new Exception("There was no results found for the id" + id);
            }

            var pet = _petRepo.ReadByID(id);
            if (pet.PreviousOwner != null)
            {
                pet.PreviousOwner = _ownerRepo.ReadOwnerById(pet.PreviousOwner.Id);            
            }
            
            return pet;
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
            if (changedPet == null)
            {
                throw new Exception("The pet you searched for could not be found.");
            }
            
            if (pet.Name != null)
            {
                changedPet.Name = pet.Name;
            }

            if (pet.Type != null)
            {
                changedPet.Type = pet.Type;
            }

            if (pet.Color != null)
            {
                changedPet.Color = pet.Color;
            }
            
            if (pet.Birthday > pet.SoldDate)
            {
                throw new Exception("The sold date has to be after the birthday.");
            }
            
            if (_petRepo.ReadByID(pet.PreviousOwner.Id) == null)
            {
                throw new Exception("Please enter a valid owner Id.");
            }
            
            changedPet.Birthday = pet.Birthday;
            changedPet.SoldDate = pet.SoldDate;
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
