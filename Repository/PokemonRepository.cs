using Microsoft.EntityFrameworkCore;
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

        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }

        bool IPokemonRepository.CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _Context.Owners.FirstOrDefault(o => o.Id == ownerId);
            var categories = _Context.Categories.FirstOrDefault(o => o.Id == categoryId);

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,

            };

            _Context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = categories,
                Pokemon = pokemon,
            };

            _Context.Add(pokemonCategory);

            _Context.Add(pokemon);

            return Save();

        }

        bool IPokemonRepository.DeletePokemon(Pokemon pokemon)
        {
            _Context.Remove(pokemon);
            return Save();

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

        ICollection<Pokemon> IPokemonRepository.GetPokemons()
        {
            throw new NotImplementedException();
        }

        bool IPokemonRepository.PokemonExists(int id)
        {
            return _Context.Pokemons.Any(p => p.Id == id);
        }

        bool IPokemonRepository.Save()
        {
            throw new NotImplementedException();
        }

        bool IPokemonRepository.UpdatePokemon(Pokemon pokemon)
        {
            _Context.Update(pokemon);
            return Save();

        }
    }
}
