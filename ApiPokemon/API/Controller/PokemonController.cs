﻿using ApiPokemon.Domain.Entities;
using ApiPokemon.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Collections.Specialized.BitVector32;

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

        [HttpPost("AgregarAtaque/{id}")]
        public async Task<IActionResult> GetAtaque(string id, [FromBody] List<string> nombres)
        {

            Pokemon pokemon = await _mongodbService.GetAsyncById(id);
            Random random = new();
            List<Ataque> ataques = new List<Ataque>();
            for (int i = 0; i < nombres.Count; i++)
            {
                var x = random.Next(0, 40);
                ataques.Add(new Ataque { nombre = nombres[i], poder = x });
            }
            pokemon.ataques = ataques;

            await _mongodbService.UpdateAsync(id, pokemon);

            return Ok(pokemon);
        }



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
