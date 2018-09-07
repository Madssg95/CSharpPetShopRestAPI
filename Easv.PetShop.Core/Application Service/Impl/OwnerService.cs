using System.Collections.Generic;
using System.Linq;
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
            return _ownerRepository.UpdateOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }
    }
}