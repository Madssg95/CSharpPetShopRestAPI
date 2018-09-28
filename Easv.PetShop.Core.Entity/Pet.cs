using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Easv.PetShop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime SoldDate { get; set; }

        public Color Color { get; set; }

        public Owner Owner { get; set; }

        public double Price { get; set; }

        public List<PetColor> PetColors { get; set; }
    }
}
