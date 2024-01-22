using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _dataContext;

        public OwnerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        Owner IOwnerRepository.GetOwner(int ownerId)
        {
            return _dataContext.Owners.SingleOrDefault(o => o.Id == id);        }

        ICollection<Owner> IOwnerRepository.GetOwnerOfAPokemon(int pokeId)
        {
            return _dataContext.PokemonOwners.Where(p => p.PokemonId == pokeId).Select(o => o.Owner).ToList();
        }

        ICollection<Owner> IOwnerRepository.GetOwners()
        {
            return _dataContext.Owners.ToList();
        }

        ICollection<Pokemon> IOwnerRepository.GetPokemonByOwner(int ownerId)
        {
            return _dataContext.PokemonOwners.Where(p => p.OwnerId == ownerId).Select(p => p.Pokemon).ToList();

        }

        bool IOwnerRepository.OwnerExists(int ownerId)
        {
            return _dataContext.Owners.Any(o => o.Id == ownerId);
        }
    }
}
