using ApiPokemon.Domain.Entities;
using ApiPokemon.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemon.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly MongoDbService _mongodbService;
        public PokemonController(MongoDbService mongoDbService) => _mongodbService = mongoDbService;

        [HttpGet("GetAll")]
        public async Task<List<Pokemon>> Get() => await _mongodbService.GetAllAsync();

        [HttpGet("GetFirst")]
        public async Task<Pokemon> GetPokemonFirst()
        {
            var pokemon = await _mongodbService.GetFirstAsync();

            if(pokemon == null)
            {
                return null;
            }
            return pokemon;
        }

        [HttpGet("GetAllByType/{tipo}")]

        public async Task<List<Pokemon>> GetAllByType(string tipo)
        {
            return await _mongodbService.GetAllByTypeAsync(tipo);
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody]Pokemon pokemon)
        {
            await _mongodbService.CreateAsync(pokemon);
            return Ok(pokemon);
            //return CreatedAtAction(nameof(Get), new { id = pokemon.Id }, pokemon);
        }

        [HttpPost("CreateManyAsync")]

        public async Task<IActionResult> CreateManyAsync([FromBody] List<Pokemon> pokemons)
        {
            await _mongodbService.CreateManyAsync(pokemons);
            return Ok(pokemons);
        }



        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody]Pokemon pokemon)
        {
            var pokemonToUpdate = await _mongodbService.GetAsyncById(id);
            if (pokemonToUpdate == null)
            {
                return NotFound();
            }
            pokemon.id = pokemonToUpdate.id;
            await _mongodbService.UpdateAsync(id, pokemon);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task <IActionResult> Delete(string id)
        {
            var pokemon = await _mongodbService.GetAsyncById(id);
            if(pokemon == null)
            {
                return NotFound();
            }
            await _mongodbService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("GetRandomAsync")]
        public async Task<Pokemon> GetPokemonRandom()
        {
            var pokemon = await _mongodbService.GetRandomAsync();

            if (pokemon == null)
            {
                return null;
            }
            return pokemon;
        }

    }
}
