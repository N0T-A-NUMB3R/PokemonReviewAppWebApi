using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _Context;
        public PokemonRepository(DataContext context) 
        {
            _Context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _Context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        Pokemon IPokemonRepository.GetPokemon(int PokeId)
        {
            return _Context.Pokemons.Where(p => p.Id == PokeId).SingleOrDefault();
        }
          
        Pokemon IPokemonRepository.GetPokemon(string Name)
        {
            return _Context.Pokemons.Where(p => p.Name == Name).FirstOrDefault();
        }

        int IPokemonRepository.GetPokemonRating(int pokemonId)
        {
            var review = _Context.Reviews.Where(p => p.Id == pokemonId);
            if (review.Count() == 0)
            {
                return 0;
            }
            return review.Sum(r => r.Rating) / review.Count();
        }

       

        bool IPokemonRepository.PokemonExists(int id)
        {
            return _Context.Pokemons.Any(p => p.Id == id);
        }
    }
}
