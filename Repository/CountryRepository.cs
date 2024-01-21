using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        //private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        
        public CountryRepository(DataContext context)
        {
            _dataContext = context;
        }

        bool ICountryRepository.CountryExists(int id)
        {
            return _dataContext.Countries.Any(c => c.Id == id);
        }

        ICollection<Country> ICountryRepository.GetCountries()
        {
            return _dataContext.Countries.OrderBy(c => c.Id).ToList();
        }

        Country ICountryRepository.GetCountry(int id)
        {
            return _dataContext.Countries.SingleOrDefault(c => c.Id == id);
        }

        Country ICountryRepository.GetCountryByOwner(int ownerId)
        {
            return _dataContext.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        ICollection<Owner> ICountryRepository.GetOwnerFromACountry(int countryId)
        {
            return _dataContext.Owners.Where(c => c.Id == countryId).ToList();
        }
    }
}
