<h1>En caso de usar reqBin: </h1>

Traer todos los Pokemon
--------------------------------
Dirección http para revisar todos los pokemon existentes

```
https://localhost:7192/api/Pokemon/GetAll
```

Crear un Pokemon
--------------------------------
Dirección http para crear un pokemon, este no tendra ataques por defecto:
```
https://localhost:7192/api/Pokemon/CreateOnePokemonAsync
```
. json:
```
{
  "nombre": "string",
  "tipo": "string",
  "defensa": 0,
  
}
```
Crear los ataques de los pokemon
--------------------------------
Dirección http para crear los ataques, escribiendo los nombres de estos:

(En la parte de la direccion "{id}", cambiar {id} por el id del pokemon que se le crearan los ataques.

Ejemplo: https://localhost:7192/api/Pokemon/CreateAtaque/66410b87aa0876901e5f14e3 )

```
https://localhost:7192/api/Pokemon/CreateAtaque/{id}
```
. json:
```
[
  "string",
  "string",
  "string",
  "string"
]
```
Crear varios Pokemon
--------------------------------
Dirección http para crear varios pokemon:

```
https://localhost:7192/api/Pokemon/CreateManyAsync
```


Para añadir más, toca despues de la llave añadir una coma y agregar las propiedades de un pokemon entre otras llaves.

Ejemplo:

{
    "nombre": "string",
    "tipo": "string",
    "defensa": 0,
  }<strong> ,
  
  
  {
    "nombre": "Pikachu",
    "tipo": "Rayo",
    "defensa": 3,
  }
  </strong>

. json:
  
```
[
  {
    "nombre": "string",
    "tipo": "string",
    "defensa": 0,
  },
  {
    "nombre": "string",
    "tipo": "string",
    "defensa": 0,
  }
]
```
Traer un Pokemon
--------------------------------
Dirección http para traer un pokemon:

```
https://localhost:7192/api/Pokemon/GetPokemonFirst
```
Traer un Pokemon random
--------------------------------
Dirección http para traer un pokemon random:

```
https://localhost:7192/api/Pokemon/GetRandomPokemonAsync
```
Traer todos los Pokemon de un tipo
--------------------------------
Dirección http para traer todos los Pokemon de un tipo:

(En la parte de la direccion "{tipo}", cambiar {tipo} por el tipo de pokemon que se quiera buscar.

Ejemplo: https://localhost:7192/api/Pokemon/GetAllByType/Lolero 
)

```
hhttps://localhost:7192/api/Pokemon/GetAllByType/{tipo}
```
Editar un pokemon
--------------------------------
Dirección http para editar un pokemon por id:

(En la parte de la direccion "{id}", cambiar {id} por el id del pokemon que se le crearan los ataques.

Ejemplo: https://localhost:7192/api/Pokemon/Update/663856d9086f3a929d785752'
)

```
hhttps://localhost:7192/api/Pokemon/Update/{id}
```
Eliminar un pokemon
--------------------------------
Dirección http para eliminar un pokemon por id:

(En la parte de la direccion "{id}", cambiar {id} por el id del pokemon que se le crearan los ataques.

Ejemplo: https://localhost:7192/api/Pokemon/DeletePokemon/663856d9086f3a929d785752'
)

```
hhttps://localhost:7192/api/Pokemon/DeletePokemon/{id}
```