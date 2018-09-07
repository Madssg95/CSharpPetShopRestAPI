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
    public class OwnersController : ControllerBase
    {
        
       private readonly IOwnerService _ownerService;

       public OwnersController(IOwnerService ownerService)
       {
          _ownerService = ownerService;
       }
        
    }
}