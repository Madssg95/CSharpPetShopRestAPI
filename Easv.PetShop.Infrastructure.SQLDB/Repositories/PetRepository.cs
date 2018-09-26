using System.Collections.Generic;
using System.Linq;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

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
           /* if (pet.Owner != null && 
                _ctx.ChangeTracker.Entries<Owner>()
                    .FirstOrDefault(ce => ce.Entity.Id == pet.Owner.Id) == null)
            {
                _ctx.Attach(pet.Owner);
            }
            
            var newPet = _ctx.Add(pet).Entity;
            _ctx.SaveChanges();
            return newPet;
            */
            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            if (filter.CurrentPage == 0 && filter.ItemsPerPage == 0)
            {
                return _ctx.Pets;
            }

            return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);

        }

        public Pet ReadByID(int id)
        {
            return _ctx.Pets.Include(p => p.Owner).FirstOrDefault(p => p.Id == id);
        }

        public Pet UpdatePet(Pet pet)
        {
            /*
             if (pet.Owner != null && 
                _ctx.ChangeTracker.Entries<Owner>()
                    .FirstOrDefault(ce => ce.Entity.Id == pet.Owner.Id) == null)
            {
                _ctx.Attach(pet.Owner);
            }
            else
            {
                _ctx.Entry(pet).Reference(p => p.Owner).IsModified = true;
            }
            var newPet = _ctx.Update(pet).Entity;
            */
            _ctx.Attach(pet).State = EntityState.Modified;
            _ctx.Entry(pet).Reference(p => p.Owner).IsModified = true;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet DeletePet(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            return _ctx.Pets.Count();
        }
    }
}