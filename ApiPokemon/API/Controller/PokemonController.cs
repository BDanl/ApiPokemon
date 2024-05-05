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

        [HttpGet]
        public async Task<List<Pokemon>> Get() => await _mongodbService.GetAsync();

        [HttpGet("Get/{id}")]
        public async Task<Pokemon> GetById(string id)
        {
            var pokemon = await _mongodbService.GetAsyncById(id);

            if(pokemon == null)
            {
                return null;
            }
            return pokemon;
        }

        [HttpPost("CreateAsync")]
        public async Task <IActionResult> CreateAsync(Pokemon pokemon)
        {
            await _mongodbService.CreateAsync(pokemon);
            return CreatedAtAction(nameof(Get), new {id = pokemon.Id}, pokemon);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, Pokemon pokemon)
        {
            var pokemonToUpdate = await _mongodbService.GetAsyncById(id);
            if (pokemonToUpdate == null)
            {
                return NotFound();
            }
            pokemon.Id = pokemonToUpdate.Id;
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
    }
}
