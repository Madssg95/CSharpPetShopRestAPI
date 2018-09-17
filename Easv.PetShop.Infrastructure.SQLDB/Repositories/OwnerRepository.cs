using System.Collections.Generic;
using System.Linq;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;

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
            var own = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return own;
        }

        public IEnumerable<Owner> ReadOwner()
        {
            return _ctx.Owners;
        }

        public Owner ReadOwnerById(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.Id == id);
        }

        public Owner UpdateOwner(Owner updateOwner)
        {
            throw new System.NotImplementedException();
        }

        public Owner DeleteOwner(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}