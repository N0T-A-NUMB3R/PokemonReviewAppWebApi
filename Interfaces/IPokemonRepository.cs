using PokemonReviewApp.Models;
using System.Globalization;

namespace PokemonReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(String Name);

        int GetPokemonRating(int pokemonId);

        bool PokemonExists(int id);

        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);

        bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon);

        bool Save();


    }
}
