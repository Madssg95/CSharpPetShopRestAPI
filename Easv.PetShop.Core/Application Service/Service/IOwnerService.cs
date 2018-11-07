using System;
using System.Collections.Generic;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Application_Service.Service
{
    public interface IOwnerService
    {
        //Create
        Owner AddOwner(Owner owner);
        //Owner NewOwner(string firstname, string lastname, string address, int phoneNumber);

        //Read
        List<Owner> GetOwners();
        List<Owner> GetFilteredOwners(Filter filter);
        Owner GetOwnerById(int id);
        Owner GetOwnerByIdIncludePets(int id);

        //Update
        Owner UpdateOwner(Owner owner);

        //Delete
        Owner DeleteOwner(int id);
    }
}