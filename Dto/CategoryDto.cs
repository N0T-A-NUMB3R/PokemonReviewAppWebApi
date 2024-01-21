using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonReviewApp.Dto
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

      