using Easv.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Infrastructure.Data
{
    public class FakeDB
    {
        public static int PetId = 1;
        public static int OwnerId = 1;
        public static IEnumerable<Pet> ListOfPets = new List<Pet>();
        public static IEnumerable<Owner> ListOfOwners = new List<Owner>();
    }
}
