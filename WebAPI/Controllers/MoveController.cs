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
    public class MoveController : Controller
    {
        private IBL _bl;

        public MoveController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<MoveController>
        [HttpGet]
        public async Task<IEnumerable<Move>> Get()
        {
            return await _bl.GetMoveListAsync();
        }

        // GET api/<MoveController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Move selectedMove = await _bl.GetMovesFromElementIdAsync(id);
            if (selectedMove != null)
            {
                return Ok(selectedMove);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<MoveController>/5
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Move move)
        {
            Move addMove = await _bl.AddMoveAsync(move);
            return Created("api/[controller]", addMove);
        }

        // PUT api/<MoveController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeleteMoveAsync(id);
        }
    }
}
