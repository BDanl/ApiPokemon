using ApiPokemon.Domain.Entities;
using ApiPokemon.Infrastructure.Services;
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
        public async Task<List<Pokemon>> GetAll() => await _mongodbService.GetAllAsync();

        [HttpPost("CreateAtaque/{id}")]
        public async Task<IActionResult> CreateAtaque(string id, [FromBody] List<string> nombres)
        {

            Pokemon pokemon = await _mongodbService.GetAsyncById(id);
            Random random = new();

            for (int i = 0; i < nombres.Count; i++)
            {
                var x = random.Next(0, 40);
                pokemon.ataques?.Add(new Ataque { nombre = nombres[i], poder = x });
            }

            await _mongodbService.UpdateAsync(id, pokemon);

            return Ok(pokemon);
        }

        [HttpGet("GetPokemonFirst")]
        public async Task<Pokemon> GetPokemonFirst()
        {
            var pokemon = await _mongodbService.GetFirstAsync();

            if (pokemon == null)
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

        [HttpPost("CreateOnePokemonAsync")]
        public async Task<IActionResult> CreateOneAsync([FromBody] Pokemon pokemon)
        {
            if (pokemon.ataques == null)
            {
                pokemon.ataques = new List<Ataque> { };
            }
            await _mongodbService.CreateAsync(pokemon);
            return Ok(pokemon);
        }

        [HttpPost("CreateManyAsync")]

        public async Task<IActionResult> CreateManyPokemonAsync([FromBody] List<Pokemon> pokemons)
        {
            foreach (var pokemon in pokemons)
            {
                if (pokemon.ataques == null)
                {
                    pokemon.ataques = new List<Ataque> { };
                }
            }
            await _mongodbService.CreateManyAsync(pokemons);
            return Ok(pokemons);
        }

        [HttpDelete("DeletePokemon/{id}")]
        public async Task<IActionResult> DeletePokemon(string id)
        {
            var pokemon = await _mongodbService.GetAsyncById(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            await _mongodbService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("GetRandomPokemonAsync")]
        public async Task<Pokemon> GetRandomPokemonAsync()
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
