using ApiPokemon.Domain.Entities;
using ApiPokemon.Infrastructure.DataBase;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiPokemon.Infrastructure.Services
{
    public class MongoDbService
    {
        
        private readonly IMongoCollection<Pokemon> _pokemons;
        private Random _random = new();
        public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(
                mongoDbSettings.Value.ConnectionUrl);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDbSettings.Value.DatabaseName );

            _pokemons = mongoDatabase.GetCollection<Pokemon>("Pokemon");
        }

        public async Task<Pokemon> GetAsyncById(string id) => await _pokemons.Find(pokemon => pokemon.id == id).FirstOrDefaultAsync();  
        public async Task <List<Pokemon>> GetAllAsync() => await _pokemons.Find(_ => true).ToListAsync();
        public async Task<Pokemon> GetFirstAsync() => await _pokemons.Find(pokemon => true).FirstOrDefaultAsync();
        public async Task <List<Pokemon>> GetAllByTypeAsync(string tipo) => await _pokemons.Find(pokemon => pokemon.tipo==tipo).ToListAsync();
        public async Task CreateAsync(Pokemon pokemon) => await _pokemons.InsertOneAsync(pokemon);
        public async Task CreateManyAsync(List<Pokemon> pokemons) => await _pokemons.InsertManyAsync(pokemons);
        public async Task UpdateAsync(string id, Pokemon pokemon) => await _pokemons.ReplaceOneAsync(pokemon => pokemon.id == id, pokemon);
        public async Task DeleteAsync(string id) => await _pokemons.DeleteOneAsync(pokemon => pokemon.id == id);
        //public async Task<Pokemon> GetRandomAsync() => await _pokemons.Find(pokemon => true).SortBy(pokemon => _random.Next()).FirstOrDefaultAsync();
        public async Task<Pokemon> GetRandomAsync() {
             var datos = _pokemons.AsQueryable();
             return datos.Skip(_random.Next(datos.Count())).FirstOrDefault();
        } 


    }
}
