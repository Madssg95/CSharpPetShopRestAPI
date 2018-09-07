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
            return _ownerService.AddOwner(owner);
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public Owner Put(int id, [FromBody] Owner owner)
        {
            _ownerService.UpdateOwner(owner);
            return owner;
        }
    }
}