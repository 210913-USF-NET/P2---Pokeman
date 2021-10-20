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
    public class UserController : Controller
    {

        private IBL _bl;

        public UserController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _bl.GetUserListAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User selectedUser = await _bl.GetUserByIdAsync(id);
            if (selectedUser != null)
            {
                return Ok(selectedUser);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            User addUser = await _bl.AddUserAsync(user);
            return Created("api/[controller]", addUser);
        }

    }
}
