using System.Collections.Generic;
using System.Linq;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Infrastructure.SQLDB.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetShopContext _ctx;

        public PetRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet pet)
        {
            if (pet.Owner != null)
            {
                _ctx.Attach(pet.Owner);
            }
            
            var newPet = _ctx.Add(pet).Entity;
            _ctx.SaveChanges();
            return newPet;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet ReadByID(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id == id);
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