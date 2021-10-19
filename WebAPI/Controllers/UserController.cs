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
<<<<<<< HEAD
    [Route("api/[controller]")]
    [ApiController]
=======
    [ApiController]
    [Route("[controller]")]

>>>>>>> f415a938f93098dfa403a215179b2f5f70a1cd62
    public class UserController : Controller
    {

        private IBL _bl;

        public UserController(IBL bl)
        {
            _bl = bl;
        }

<<<<<<< HEAD

=======
        // POST api/<UserController>
>>>>>>> f415a938f93098dfa403a215179b2f5f70a1cd62
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            User addUser = await _bl.AddUserAsync(user);
            return Created("api/[controller]", addUser);
        }

    }
}
