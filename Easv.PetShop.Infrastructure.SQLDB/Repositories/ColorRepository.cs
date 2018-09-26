using System.Collections.Generic;
using System.Linq;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Easv.PetShop.Infrastructure.SQLDB.Repositories
{
    public class ColorRepository : IColorRepository
    {
        
        readonly PetShopContext _ctx;

        public ColorRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        
        public Color CreateColor(Color color)
        {
            _ctx.Attach(color).State = EntityState.Added;
            _ctx.SaveChanges();
            return color;
        }

        public IEnumerable<Color> ReadColors()
        {
            return _ctx.Colors;
        }

        public Color ReadColorById(int id)
        {
            return _ctx.Colors.FirstOrDefault(c => c.Id == id);
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