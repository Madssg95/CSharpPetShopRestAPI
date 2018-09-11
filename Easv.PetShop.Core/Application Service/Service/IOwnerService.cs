using System;
using System.Collections.Generic;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Application_Service.Service
{
    public interface IOwnerService
    {
        //Create
        Owner AddOwner(Owner owner);
        Owner NewOwner(string firstname, string lastname, string address, int phoneNumber, List<Pet> pets );

        //Read
        List<Owner> GetOwners();
        Owner GetOwnerById(int id);

        //Update
        Owner UpdateOwner(Owner owner);

        //Delete
        Owner DeleteOwner(int id);
    }
}