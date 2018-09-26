using System;
using System.Collections.Generic;
using System.Linq;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;

namespace Easv.PetShop.Core.Application_Service.Impl
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public Color CreateColor(Color color)
        {
            if (color.PetColor == null)
            {
                throw new Exception("You have to enter a color in order to create one.");
            }
            return _colorRepository.CreateColor(color);
        }

        public List<Color> ReadColors()    
        {
            return _colorRepository.ReadColors().ToList();
        }

        public Color ReadColorById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Color UpdateColor(int id)
        {
            throw new System.NotImplementedException();
        }

        public Color DeleteColor(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}