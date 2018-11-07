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
        public ActionResult<IEnumerable<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_ownerService.GetFilteredOwners(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                return Ok(_ownerService.GetOwnerByIdIncludePets(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // POST api/values
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
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
            owner.Id = id;
            try
            {
                return Ok(_ownerService.UpdateOwner(owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            try
            {
                _ownerService.DeleteOwner(id);
                return Ok($"The user with the Id: {id} was deleted.");
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
            
        }
    }
}