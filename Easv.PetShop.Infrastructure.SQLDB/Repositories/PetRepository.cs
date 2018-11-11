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

            if (filter.SortBy.ToLower() == "type")
            {
                if (filter.SortOrder.ToLower() == "ascending")
                {
                    return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                        .OrderBy(p => p.Type);
                }
                return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                        .OrderByDescending(p => p.Type);
            }

            if (filter.SortBy.ToLower() == "price")
            {
                if (filter.SortOrder.ToLower() == "ascending")
                {
                    return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                        .OrderBy(p => p.Price);
                }
                return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                    .OrderByDescending(p => p.Type);
            }

            if (filter.SortBy.ToLower() == "age")
            {
                if (filter.SortOrder.ToLower() == "ascending")
                {
                    return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                        .OrderBy(p => p.Birthday);
                }
                return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                    .OrderByDescending(p => p.Birthday);
            }
            
            if (filter.SortBy.ToLower() == "solddate")
            {
                if (filter.SortOrder.ToLower() == "ascending")
                {
                    return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                        .OrderBy(p => p.SoldDate);
                }
                return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                    .OrderByDescending(p => p.SoldDate);
            }
            
            if (filter.SortBy.ToLower() == "name")
            {
                if (filter.SortOrder.ToLower() == "ascending")
                {
                    return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                        .OrderBy(p => p.Name);
                }
                return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage)
                    .OrderByDescending(p => p.Name);
            }

            return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);

        }

        public Pet ReadByID(int id)
        {
            return _ctx.Pets.Include(p => p.Owner).Include(p => p.Color).FirstOrDefault(p => p.Id == id);
        }

        public Pet UpdatePet(Pet pet)
        {
            _ctx.Attach(pet).State = EntityState.Modified;
            _ctx.Entry(pet).Reference(p => p.Owner).IsModified = true;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet DeletePet(int id)
        {
            var deletePet = _ctx.Remove(new Pet() {Id = id}).Entity;
            _ctx.SaveChanges();
            return deletePet;
        }

        public int Count()
        {
            return _ctx.Pets.Count();
        }
    }
}