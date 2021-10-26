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
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        
        private IBL _bl;
        
        public MessageController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<MessageController>
        [HttpGet]
        public async Task<IEnumerable<Message>> Get()
        {
            return await _bl.GetMessageAsync();
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Message selectedMessage = await _bl.GetMessageByIdAsync(id);
            if (selectedMessage != null)
            {
                return Ok(selectedMessage);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<MessageController>/5
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Message message)
        {
            Message addMessage = await _bl.AddMessageAsync(message);
            return Created("api/[controller]", addMessage);
        }

        // PUT api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteMessageAsync(id);
        }

    }
}
