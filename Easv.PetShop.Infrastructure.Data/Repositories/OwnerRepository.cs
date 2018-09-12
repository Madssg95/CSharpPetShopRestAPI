using System.Collections.Generic;
using System.Linq;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        public OwnerRepository()
        {
            if (FakeDB.ListOfOwners.Any()) return;

            var owner1 = new Owner()
            {
                Id = FakeDB.OwnerId++,
                FirstName = "Karl",
                LastName = "Karlson",
                Address = "Karlvej 10",
                PhoneNumber = 12345678,
            };
            var owner2 = new Owner()
            {
                Id = FakeDB.OwnerId++,
                FirstName = "Mikkel",
                LastName = "Mikkelsen",
                Address = "Mikkelvej 10",
                PhoneNumber = 87654321
            };

            var owners = FakeDB.ListOfOwners.ToList();
            owners.Add(owner1);
            owners.Add(owner2);
            FakeDB.ListOfOwners = owners;
        }

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
            var owners = ReadOwner();
            var owner = owners.FirstOrDefault(owner1 => owner1.Id == updateOwner.Id);
            FakeDB.ListOfOwners = owners;
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