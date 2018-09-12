using System.Collections.Generic;

namespace Easv.PetShop.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public List<Pet> Pets { get; set; }
    }
}