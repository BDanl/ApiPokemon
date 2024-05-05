using MongoDB.Bson.Serialization.Attributes;

namespace ApiPokemon.Domain.Entities
{
    public class Pokemon
    {
        public Pokemon(string nombre, string tipo, int defensa, List<Ataque> ataques)
        {
            Nombre = nombre;
            Tipo = tipo;
            Defensa = defensa;
            Ataques = ataques;
        }
        [BsonId]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Defensa { get; set; }
        public List<Ataque> Ataques { get; set; }

    }
}
