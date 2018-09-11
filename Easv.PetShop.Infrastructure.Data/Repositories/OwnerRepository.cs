using System.Collections.Generic;
using System.Linq;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = FakeDB.OwnerId++;
            var owners = FakeDB.ListOfOwners.ToList();
            owners.Add(owner);
            FakeDB.ListOfOwners = owners;
            return owner;
        }

        public IEnumerable<Owner> ReadOwner()
        {
            return FakeDB.ListOfOwners;
        }

        public Owner ReadOwnerById(int id)
        {
            var owners = FakeDB.ListOfOwners;
            var matchingOwner = owners.FirstOrDefault(owner => owner.Id == id);
            return matchingOwner;
        }

        public Owner UpdateOwner(Owner updateOwner)
        {
            var owner = ReadOwner().FirstOrDefault(own => own.Id == updateOwner.Id);
            if (owner == null) return owner;
            owner.Id = updateOwner.Id;
            owner.Name = updateOwner.Name;
            owner.Address = updateOwner.Address;
            owner.PhoneNumber = updateOwner.PhoneNumber;
            owner.Pets = updateOwner.Pets;

            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var owner = ReadOwnerById(id);
            var owners = ReadOwner().ToList();
            owners.Remove(owner);
            FakeDB.ListOfOwners = owners;
            return owner;
        }
    }
}