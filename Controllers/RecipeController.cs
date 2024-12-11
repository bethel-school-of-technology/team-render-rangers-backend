using feastly_api.Models;
using feastly_api.Repositories;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

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

        private int? GetUserIdFromToken()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return null;
            }
            return userId;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("user/{recipeId:int}")]
        public async Task<ActionResult<Recipe?>> GetOneUserRecipe(int recipeId)
        {
            var userId = GetUserIdFromToken();
            if (userId == null)
            {
                return Unauthorized();
            }

            var recipe = await _recipeRepository.GetOneUserRecipe(userId.Value, recipeId);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAllUserRecipes()
        {
            var userId = GetUserIdFromToken();
            if (userId == null)
            {
                return Unauthorized();
            }

            var recipes = await _recipeRepository.GetAllUserRecipes(userId.Value);
            return Ok(recipes);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
        {
            if (!ModelState.IsValid || newRecipe == null)
            {
                return BadRequest();
            }

            var userId = GetUserIdFromToken();
            if (userId == null)
            {
                return Unauthorized();
            }

            newRecipe.UserId = userId.Value;
            var createdRecipe = await _recipeRepository.CreateRecipe(newRecipe);

            return CreatedAtAction(nameof(GetAllRecipes), new { recipeId = createdRecipe.RecipeId }, createdRecipe);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [Route("{recipeId:int}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe updatedRecipe, int recipeId)
        {
            if (!ModelState.IsValid || updatedRecipe == null || updatedRecipe.RecipeId != recipeId)
            {
                return BadRequest();
            }

            var userId = GetUserIdFromToken();
            if (userId == null)
            {
                return Unauthorized();
            }

            updatedRecipe.UserId = userId.Value;

            var recipeUpdate = await _recipeRepository.UpdateRecipe(userId.Value, updatedRecipe);
            if (recipeUpdate == null)
            {
                var recipeExists = await _recipeRepository.GetRecipe(recipeId);
                if (recipeExists != null)
                {
                    return Forbid();
                }
                return NotFound();
            }
            return Ok(recipeUpdate);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{recipeId:int}")]
        public async Task<IActionResult> DeleteRecipe(int recipeId)
        {
            var userId = GetUserIdFromToken();
            if (userId == null)
            {
                return Unauthorized();
            }

            // TODO: revisit these validations

            var existingRecipe = await _recipeRepository.GetRecipe(recipeId);

            if (existingRecipe == null)
            {
                return NotFound();
            }

            if (existingRecipe.UserId != userId)
            {
                return Forbid();
            }

            await _recipeRepository.DeleteRecipe(userId.Value, recipeId);
            return NoContent();
        }
    }
}