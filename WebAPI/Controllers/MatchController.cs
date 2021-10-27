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
    public class MatchController : Controller
    {
        private IBL _bl;

        public MatchController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<MatchController>
        [HttpGet]
        public async Task<IEnumerable<Match>> Get()
        {
            return await _bl.GetMatchAsync();
        }

        // GET api/<MatchController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Match selectedMatch = await _bl.GetMatchByIdAsync(id);
            if (selectedMatch != null)
            {
                return Ok(selectedMatch);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<MatchController>/5
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Match match)
        {
            Match addMatch = await _bl.AddMatchAsync(match);
            return Created("api/[controller]", addMatch);
        }

        // PUT api/<MatchController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteMatchAsync(id);
        }
    }
}
