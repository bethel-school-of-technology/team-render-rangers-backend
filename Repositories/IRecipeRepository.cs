using feastly_api.Models;

namespace feastly_api.Repositories;

public interface IRecipeRepository {
    Task<IEnumerable<Recipe>> GetAllRecipes();

    Task<Recipe> CreateRecipe(Recipe newRecipe);

    Task<Recipe> DeleteRecipe(int recipeId);
}