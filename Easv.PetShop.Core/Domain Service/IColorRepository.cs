using System.Collections.Generic;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Domain_Service
{
    public interface IColorRepository
    {
       //Create
        Color CreateColor(Color color);
        
        //Read
        IEnumerable<Color> ReadColors();
        Color ReadColorById(int id);
        
        //Update
        Color UpdateColor(int id);
        
        //Delete
        Color DeleteColor(int id);

    }
}