using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Easv.PetShop.Infrastructure.SQLDB.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly PetShopContext _ctx;

        public OwnerRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Owner CreateOwner(Owner owner)
        {
            _ctx.Owners.Attach(owner).State = EntityState.Added;
            _ctx.SaveChanges();
            return owner;
        }

        public IEnumerable<Owner> ReadOwner()
        {
            return _ctx.Owners;
        }

        public Owner ReadOwnerById(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.Id == id);
        }

        public Owner ReadOwnerByIdIncludePets(int id)
        {
            return _ctx.Owners.Include(o => o.Pets).FirstOrDefault(o => o.Id == id);
        }

        public Owner UpdateOwner(Owner updateOwner)
        {
            _ctx.Attach(updateOwner).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updateOwner;
        }

        public Owner DeleteOwner(int id)
        {
            var owner = _ctx.Remove(new Owner() {Id = id}).Entity;
            _ctx.SaveChanges();
            return owner;
        }
    }
}