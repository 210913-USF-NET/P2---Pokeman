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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private IBL _bl;

        public UserController(IBL bl)
        {
            _bl = bl;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            User addUser = await _bl.AddUserAsync(user);
            return Created("api/[controller]", addUser);
        }

    }
}
