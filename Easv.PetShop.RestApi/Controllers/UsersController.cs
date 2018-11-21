using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easv.PetShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post([FromBody] LoginInputModel model)
        {
            var user = new User
            {
                Username = model.Username
            };
            try
            {
                return _userService.AddUser(user, model.Password);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            user.Id = id;
            try
            {
                return Ok(_userService.UpdateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            if (_userService.DeleteUser(id) == null || id < 1)
            {
                return StatusCode(404, "Did not find the owner with Id:" + id);
            }
            return Ok($"The user with the Id: {id} was deleted.");
        }
    }
}
        