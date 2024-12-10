// using MySql.Data.MySqlClient;
// using feastly_api.Models;
// using System.Data;

// namespace feastly_api.Repositories
// {
//     public class SQLRecipeRepo(IConfiguration configuration) : IRecipeRepository
//     {
//         private readonly string? _myConnectionString = configuration.GetConnectionString("DefaultConnection");

//         public async Task<IEnumerable<Recipe>> GetAllRecipes()
//         {
//             var recipeList = new List<Recipe>();

//             using (var conn = new MySqlConnection(_myConnectionString))
//             {
//                 await conn.OpenAsync();

//                 string query = "SELECT * FROM recipe;";
//                 using (var command = new MySqlCommand(query, conn))
//                 {
//                     var reader = command.ExecuteReader();

//                     while (reader.Read())
//                     {
//                         recipeList.Add(new Recipe
//                         {
//                             RecipeId = reader.GetInt32("recipeId"),
//                             RecipeCategory = reader.GetString("recipeCategory"),
//                             RecipeName = reader.GetString("recipeName"),
//                             RecipeIngredients = reader.GetString("recipeIngredients"),
//                             RecipeInstructions = reader.GetString("recipeInstructions"),
//                             RecipeImgUrl = reader.GetString("recipeImgUrl"),
//                         });
//                     }
//                 }
//             }
//             return await Task.FromResult(recipeList);
//         }

//         public async Task<Recipe?> GetRecipe(int recipeId)
//         {
//             using (var conn = new MySqlConnection(_myConnectionString))
//             {
//                 await conn.OpenAsync();

//                 string query = "SELECT * FROM recipe WHERE recipeId = @recipeId;";
//                 using (var command = new MySqlCommand(query, conn))
//                 {
//                     command.Parameters.AddWithValue("@recipeId", recipeId);
//                     using (var reader = await command.ExecuteReaderAsync())
//                     {
//                         if (await reader.ReadAsync())
//                         {
//                             return new Recipe
//                             {
//                                 RecipeId = reader.GetInt32("recipeId"),
//                                 RecipeCategory = reader.GetString("recipeCategory"),
//                                 RecipeName = reader.GetString("recipeName"),
//                                 RecipeIngredients = reader.GetString("recipeIngredients"),
//                                 RecipeInstructions = reader.GetString("recipeInstructions"),
//                                 RecipeImgUrl = reader.GetString("recipeImgUrl")
//                             };
//                         }
//                     }

//                 }
//             }
//             return null;
//         }

//         public async Task<Recipe> CreateRecipe(Recipe newRecipe)
//         {
//             using (var conn = new MySqlConnection(_myConnectionString))
//             {
//                 await conn.OpenAsync();

//                 string query = "INSERT INTO recipe (recipeCategory, recipeName, recipeIngredients, recipeInstructions, recipeImgUrl) VALUES(@recipeCategory, @recipeName, @recipeIngredients, @recipeInstructions, @recipeImgUrl);";
//                 using (var command = new MySqlCommand(query, conn))
//                 {
//                     command.Parameters.AddWithValue("@recipeCategory", newRecipe.RecipeCategory);
//                     command.Parameters.AddWithValue("@recipeName", newRecipe.RecipeName);
//                     command.Parameters.AddWithValue("@recipeIngredients", newRecipe.RecipeIngredients);
//                     command.Parameters.AddWithValue("@recipeInstructions", newRecipe.RecipeInstructions);
//                     command.Parameters.AddWithValue("@recipeImgUrl", newRecipe.RecipeImgUrl);

//                     await command.ExecuteNonQueryAsync();
//                     newRecipe.RecipeId = (int)command.LastInsertedId;
//                 }
//                 return newRecipe;
//             }
//         }

//         public async Task<Recipe> UpdateRecipe(Recipe updatedRecipe)
//         {
//             using (var conn = new MySqlConnection(_myConnectionString))
//             {
//                 await conn.OpenAsync();

//                 string query = "UPDATE recipe SET recipeCategory = @recipeCategory, recipeName = @recipeName, recipeIngredients = @recipeIngredients, recipeInstructions = @recipeInstructions, recipeImgUrl = @recipeImgUrl WHERE recipeId = @recipeId;";
//                 using (var command = new MySqlCommand(query, conn))
//                 {
//                     command.Parameters.AddWithValue("@recipeId", updatedRecipe.RecipeId);
//                     command.Parameters.AddWithValue("@recipeCategory", updatedRecipe.RecipeCategory);
//                     command.Parameters.AddWithValue("@recipeName", updatedRecipe.RecipeName);
//                     command.Parameters.AddWithValue("@recipeIngredients", updatedRecipe.RecipeIngredients);
//                     command.Parameters.AddWithValue("@recipeInstructions", updatedRecipe.RecipeInstructions);
//                     command.Parameters.AddWithValue("@recipeImgUrl", updatedRecipe.RecipeImgUrl);

//                     await command.ExecuteNonQueryAsync();
//                 }

//                 return updatedRecipe;
//             }
//         }

//         public async Task DeleteRecipe(int recipeId)
//         {
//             using (var conn = new MySqlConnection(_myConnectionString))
//             {
//                 await conn.OpenAsync();

//                 string query = "DELETE FROM recipe WHERE recipeId = @recipeId;";
//                 using (var command = new MySqlCommand(query, conn))
//                 {
//                     command.Parameters.AddWithValue("@recipeId", recipeId);
//                     await command.ExecuteNonQueryAsync();
//                 }
//             }
//         }
//     }
// }
