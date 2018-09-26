using System;
using System.Collections.Generic;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Easv.PetShop.RestApi.Controllers
{
    public class ColorsController : Controller
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Color>> Get()
        {
            return _colorService.ReadColors();
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                return Ok(_colorService.ReadColorById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // POST api/values
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Color color)
        {
            try
            {
                return Ok(_colorService.CreateColor(color));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Color color)
        {
            color.Id = id;
            try
            {
                return Ok(_colorService.UpdateColor(color.Id));
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
                _colorService.DeleteColor(id);
                return Ok($"The color with the Id: {id} was deleted.");
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
            
        }
    }
}