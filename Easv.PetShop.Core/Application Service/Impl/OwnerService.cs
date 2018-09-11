using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Application_Service.Impl
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner AddOwner(Owner owner)
        {
            if (owner.Name.Length < 2)
            {
                throw new Exception("The name must at least have two characters.");
            }

            if (owner.Address.Length == 0)
            {
                throw new Exception("The address you have entered is invalid.");
            }

            if (owner.PhoneNumber.ToString().Length < 8)
            {
                throw new Exception("The phone number must at least contain 8 digits.");
            }
            return _ownerRepository.CreateOwner(owner);
        }

        public Owner NewOwner(string name, string address, int phoneNumber, List<Pet> pets)
        {
            var owner = new Owner()
            {
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Pets = pets
            };
            return owner;
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadOwner().ToList();
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepository.ReadOwnerById(id);
        }

        public Owner UpdateOwner(Owner owner)
        {
            if (owner.Name.Length < 2)
            {
                throw new Exception("The name must at least have two characters.");
            }

            if (owner.Address.Length == 0)
            {
                throw new Exception("The address you have entered is invalid.");
            }

            if (owner.PhoneNumber.ToString().Length < 8)
            {
                throw new Exception("The phone number must at least contain 8 digits.");
            }
            return _ownerRepository.UpdateOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            if (_ownerRepository.DeleteOwner(id) == null || id < 1)
            {
                throw new Exception($"The Id {id} was not found.");
            }
            return _ownerRepository.DeleteOwner(id);
        }
    }
}