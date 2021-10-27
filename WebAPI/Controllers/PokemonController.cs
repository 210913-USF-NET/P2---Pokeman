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
    public class PokemonController : Controller
    {
        private IBL _bl;

        public PokemonController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<PokemonController>
        [HttpGet]
        public async Task<IEnumerable<Pokemon>> Get()
        {
            return await _bl.GetPokemonAsync();
        }

        // GET api/<PokemonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Pokemon selectedPokemon = await _bl.GetPokemonByIdAsync(id);
            if (selectedPokemon != null)
            {
                return Ok(selectedPokemon);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<PokemonController>/5
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pokemon pokemon)
        {
            Pokemon addPokemon = await _bl.AddPokemonAsync(pokemon);
            return Created("api/[controller]", addPokemon);
        }

        // PUT api/<PokemonController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Pokemon newPokemon)
        {
            Pokemon updatedPokemon = await _bl.UpdatePokemonAsync(newPokemon);
            return Ok(updatedPokemon);
        }

        // PUT api/<PokemonController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bl.DeletePokemonAsync(id);
        }
    }
}
