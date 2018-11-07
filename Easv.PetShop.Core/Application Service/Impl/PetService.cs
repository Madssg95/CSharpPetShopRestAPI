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
            if (pet.Name == null)
            {
                throw new Exception("Please enter a name");
            }

            if (pet.Type == null)
            {
                throw new Exception("Please enter a type.");
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
           
            return _petRepo.CreatePet(pet);
        }

        public Pet NewPet(string name, string type, DateTime birthday, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            return new Pet();
        }

        public Pet GetPetById(int id)
        {
            if (id < 1 || _petRepo.ReadByID(id) == null)
            {
                throw new Exception("There was no results found for the id" + id);
            }

            var pet = _petRepo.ReadByID(id);
            if (pet.Owner != null)
            {
                pet.Owner = _ownerRepo.ReadOwnerById(pet.Owner.Id);            
            }
            
            return pet;
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }
        
        public List<Pet> GetFilteredPets(Filter filter)
        {
            if (filter.ItemsPerPage < 0 || filter.CurrentPage < 0)
            {
                throw new Exception("Please enter values that are at least 0");
            }

            if (((filter.CurrentPage -1) * filter.ItemsPerPage) > _petRepo.Count()) 
            {
                throw new Exception("The current page you have selected is to high.");
            }
            
            return _petRepo.ReadPets(filter).ToList();
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
            return _petRepo.UpdatePet(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.DeletePet(id);

        }
    }
}
