using Easv.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Core.Domain_Service
{
    public interface IPetRepository
    {
        //Create
        Pet CreatePet(Pet pet);

        //Read
        IEnumerable<Pet> ReadPets();
        Pet ReadByID(int id);

        //Update
        Pet UpdatePet(Pet pet);

        //Delete
        Pet DeletePet(int id);
    }
}
