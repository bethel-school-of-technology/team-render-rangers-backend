using feastly_api.Models;

namespace feastly_api.Repositories;

public interface IRecipeRepository {
    Task<IEnumerable<Recipe>> GetAllRecipes();

    Task<Recipe?> GetRecipe(int recipeId);

    Task<Recipe?> GetOneUserRecipe(int userId, int recipeId);
    
    Task<IEnumerable<Recipe>> GetAllUserRecipes(int userId);

    Task<Recipe> CreateRecipe(Recipe newRecipe);

    Task<Recipe?> UpdateRecipe(int userId, Recipe updatedRecipe);

    Task DeleteRecipe(int userId, int recipeId);

    Task<IEnumerable<Recipe>> SearchRecipes(string query);
}