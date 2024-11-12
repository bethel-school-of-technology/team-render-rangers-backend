using feastly_api.Models;

namespace feastly_api.Repositories;

public interface IRecipeRepository {
    IEnumerable<Recipe> GetAllRecipes();
}