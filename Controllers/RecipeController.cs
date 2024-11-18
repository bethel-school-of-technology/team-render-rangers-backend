using Microsoft.AspNetCore.Mvc;
using feastly_api.Repositories;
using feastly_api.Models;

namespace feastly_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(ILogger<RecipeController> logger, IRecipeRepository repository)
        {
            _logger = logger;
            _recipeRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipes()
        {
            var recipes = await _recipeRepository.GetAllRecipes();
            return Ok(recipes);
        }


        [HttpPost]

        public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
        {
            if (!ModelState.IsValid || newRecipe == null)
            {
                return BadRequest();
            }

            var createdRecipe = await _recipeRepository.CreateRecipe(newRecipe);
            return CreatedAtAction(nameof(GetAllRecipes), new { recipeId = createdRecipe.RecipeId }, createdRecipe);
        }
    }
}