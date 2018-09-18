using System.Collections.Generic;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Domain_Service
{
    public interface IOwnerRepository
    {
        //Create
        Owner CreateOwner(Owner owner);

        //Read
        IEnumerable<Owner> ReadOwner();
        Owner ReadOwnerById(int id);
        Owner ReadOwnerByIdIncludePets(int id);

        //Update
        Owner UpdateOwner(Owner updateOwner);

        //Delete
        Owner DeleteOwner(int id);
    }
}