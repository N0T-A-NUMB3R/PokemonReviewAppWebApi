namespace PokemonReviewApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PokemonCategory> PokemonCategories { get; set; }
        /*
        public static implicit operator Category(List<Category> v)
        {
            throw new NotImplementedException();
        }
        */
    }
}
