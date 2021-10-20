using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElementController : Controller
    {
        private IBL _bl;

        public ElementController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<ElementController>
        [HttpGet]
        public async Task<IEnumerable<Element>> Get()
        {
            return await _bl.GetElementListAsync();
        }

        // GET api/<ElementController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Element selectedElement = await _bl.GetElementByIdAsync(id);
            if (selectedElement != null)
            {
                return Ok(selectedElement);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<ElementController>/5
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Element element)
        {
            Element addElement = await _bl.AddElementAsync(element);
            return Created("api/[controller]", addElement);
        }

        // PUT api/<ElementController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Element newElement)
        {
            //Shrek 5ever
            Element updatedElement = await _bl.UpdateElementAsync(newElement);
            return Ok(updatedElement);
        }

        // PUT api/<ElementController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteElementAsync(id);
        }
    }
}
