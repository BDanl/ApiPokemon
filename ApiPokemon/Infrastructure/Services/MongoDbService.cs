using ApiPokemon.Domain.Entities;
using ApiPokemon.Infrastructure.DataBase;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiPokemon.Infrastructure.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Pokemon> _pokemons;
        public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(
                mongoDbSettings.Value.ConnectionUrl);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDbSettings.Value.DatabaseName );

            _pokemons = mongoDatabase.GetCollection<Pokemon>("Pokemons");
        }

        public async Task <List<Pokemon>> GetAsync() => await _pokemons.Find(_ => true).ToListAsync();
        public async Task<Pokemon> GetAsyncById(string id) => await _pokemons.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Pokemon pokemon) => await _pokemons.InsertOneAsync(pokemon); 
        public async Task UpdateAsync(string id, Pokemon pokemon) => await _pokemons.ReplaceOneAsync(x => x.Id == id, pokemon);
        public async Task DeleteAsync(string id) => await _pokemons.DeleteOneAsync(x => x.Id == id);
    }
}
