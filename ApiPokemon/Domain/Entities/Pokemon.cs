using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiPokemon.Domain.Entities
{
    public class Pokemon
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public int defensa { get; set; }
        public List<Ataque> ataques { get; set; }

        public Pokemon(string nombre, string tipo, int defensa, List<Ataque> ataques)
        {
            
            this.nombre = nombre;
            this.tipo = tipo;
            this.defensa = defensa;
            this.ataques = ataques;
        }

    }
}
