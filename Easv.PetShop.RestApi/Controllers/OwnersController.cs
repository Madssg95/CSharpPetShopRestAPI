using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Easv.PetShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
       private readonly IOwnerService _ownerService;

       public OwnersController(IOwnerService ownerService)
       {
          _ownerService = ownerService;
       }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetOwners();
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.GetOwnerById(id);
        }
        
        // POST api/values
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                _ownerService.AddOwner(owner);
                return Ok(_ownerService.AddOwner(owner));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id )
            {
                return BadRequest("Parameter Id and owner Id must be the same");
            }
            return Ok(_ownerService.UpdateOwner(owner));
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            try
            {
                return Ok($"The user with the Id: {id} was deleted.");
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
            
        }
    }
}