using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Easv.PetShop.Core.Entity
{
    public class Color
    {
        public int Id { get; set; }
        public string PetColor { get; set; }
        public List<PetColor> PetColors { get; set; }
    }
}