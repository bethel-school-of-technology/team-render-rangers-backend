using feastly_api.Models;

namespace feastly_api.Repositories;

public interface IRecipeRepository {
    Task<IEnumerable<Recipe>> GetAllRecipes();

    Task<Recipe> GetRecipe(int recipeId);

    Task<Recipe> CreateRecipe(Recipe newRecipe);

    Task DeleteRecipe(int recipeId);
}