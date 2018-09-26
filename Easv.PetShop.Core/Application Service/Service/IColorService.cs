using System.Collections.Generic;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Application_Service.Service
{
    public interface IColorService
    {
        //Create
        Color CreateColor(Color color);
        
        //Read
        List<Color> ReadColors();
        Color ReadColorById(int id);
        
        //Update
        Color UpdateColor(int id);
        
        //Delete
        Color DeleteColor(int id);
    }
}