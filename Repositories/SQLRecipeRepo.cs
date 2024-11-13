using MySql.Data.MySqlClient;
using feastly_api.Models;

namespace feastly_api.Repositories
{
    public class SQLRecipeRpo(IConfiguration configuration) : IRecipeRepository
    {
        private readonly string? _myConnectionString = configuration.GetConnectionString("DefaultConnection");
        public IEnumerable<Recipe> GetAllRecipes()
        {
            var recipeList = new List<Recipe>();

            using (var conn = new MySqlConnection(_myConnectionString))
            {
                conn.Open();

                string query = "SELECT * FROM recipe;";
                using (var command = new MySqlCommand(query, conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        recipeList.Add(new Recipe
                        {
                            RecipeId = reader.GetInt32("recipeId"),
                            RecipeName = reader.GetString("recipeName"),
                            RecipeCategory = reader.GetString("recipeCategory"),
                            RecipeIngredients = reader.GetString("recipeIngredients"),
                            RecipeInstructions = reader.GetString("recipeInstructions"),
                            RecipeImgUrl = reader.GetString("recipeImgUrl"),
                        });
                    }
                }
            }
            return recipeList;
        }
    }
}
