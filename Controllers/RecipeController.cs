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

        [HttpGet("{recipeId:int}")]
        public async Task<ActionResult<Recipe?>> GetRecipe(int recipeId)
        {
            var recipe = await _recipeRepository.GetRecipe(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
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


        [HttpPut]
        [Route("{recipeId:int}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe updatedRecipe, int recipeId)
        {
            if (!ModelState.IsValid || updatedRecipe == null || updatedRecipe.RecipeId != recipeId)
            {
                return BadRequest();
            }

            var recipeUpdate = await _recipeRepository.UpdateRecipe(updatedRecipe);
            if (recipeUpdate == null)
            {
                return NotFound();
            }
            return Ok(recipeUpdate);
        }

        [HttpDelete("{recipeId:int}")]
        public async Task<IActionResult> DeleteRecipe(int recipeId)
        {
            var existingRecipe = await _recipeRepository.GetRecipe(recipeId);
            if (existingRecipe == null)
            {
                return NotFound();
            }
            await _recipeRepository.DeleteRecipe(recipeId);
            return NoContent();
        }
    }
}