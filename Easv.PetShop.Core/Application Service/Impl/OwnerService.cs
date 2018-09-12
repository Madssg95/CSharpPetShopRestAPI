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
            if (owner.FirstName.Length < 2 || owner.LastName.Length < 2)
            {
                throw new Exception("Both firstname and lastname must at least have two characters.");
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

        public Owner NewOwner(string firstname, string lastname, string address, int phoneNumber)
        {
            var owner = new Owner()
            {
                FirstName = firstname,
                LastName = lastname,
                Address = address,
                PhoneNumber = phoneNumber
            };
            return owner;
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadOwner().ToList();
        }

        public Owner GetOwnerById(int id)
        {
            if (id < 1 || _ownerRepository.ReadOwnerById(id) == null)
            {
                throw new Exception("There was no results found for the id" + id);
            }
            return _ownerRepository.ReadOwnerById(id);
        }

        public Owner UpdateOwner(Owner updateOwner)
        {
            
            var owner = _ownerRepository.ReadOwnerById(updateOwner.Id);
            if (updateOwner == null)
            {
                throw new Exception("The owner you searched for could not be found.");
            }

            if (updateOwner.FirstName != null)
            {
                owner.FirstName = updateOwner.FirstName;
            }

            if (updateOwner.LastName != null)
            {
                owner.LastName = updateOwner.LastName;
            }

            if (updateOwner.Address != null)
            {
                owner.Address = updateOwner.Address;

            }
            owner.PhoneNumber = updateOwner.PhoneNumber;

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