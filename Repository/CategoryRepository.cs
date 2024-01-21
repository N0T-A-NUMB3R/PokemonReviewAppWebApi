using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _DataContext;
        public CategoryRepository(DataContext dataContext) 
        { 
            _DataContext = dataContext;
        }
        
        bool ICategoryRepository.CategoryExists(int id)
        {
            return _DataContext.Categories.Any(c => c.Id == id);
        }

        ICollection<Category> ICategoryRepository.GetCategories()
        {
            return _DataContext.Categories.OrderBy(p => p.Id).ToList();
        }

        Category ICategoryRepository.GetCategory(int id)
        {
            return _DataContext.Categories.Where(p => p.Id == id).SingleOrDefault();
        }

        ICollection<Pokemon> ICategoryRepository.GetPokemonsByCategory(int categoryId)
        {
            return _DataContext.PokemonCategories.Where(pc => pc.CategoryId == categoryId).Select(pc => pc.Pokemon).ToList();
        }
    }
}
