using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Easv.PetShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.GetPetById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            return _petService.AddPet(pet);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Pet Put(int id, [FromBody] Pet pet)
        {
            var petToUpdate = _petService.GetPetById(id);
            if ( petToUpdate != null)
            {
                petToUpdate.Id = id;
                petToUpdate.Name = pet.Name;
                petToUpdate.Type = pet.Type;
                petToUpdate.Birthday = pet.Birthday;
                petToUpdate.SoldDate = pet.SoldDate;
                petToUpdate.PreviousOwner = pet.PreviousOwner;
                petToUpdate.Price = pet.Price;
            }
            return petToUpdate;
            
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Pet Delete(int id)
        {
            return _petService.DeletePet(id);
        }
    }
}
