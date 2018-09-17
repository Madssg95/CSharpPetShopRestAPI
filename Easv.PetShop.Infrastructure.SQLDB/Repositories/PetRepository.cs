using System.Collections.Generic;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Infrastructure.SQLDB.Repositories
{
    public class PetRepository : IPetRepository
    {
        public Pet CreatePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            throw new System.NotImplementedException();
        }

        public Pet ReadByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Pet UpdatePet(Pet updatePet)
        {
            throw new System.NotImplementedException();
        }

        public Pet DeletePet(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}