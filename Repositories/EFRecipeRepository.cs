using feastly_api.Models;
using feastly_api.Migrations;
using Microsoft.EntityFrameworkCore;

namespace feastly_api.Repositories;

public class EFRecipeRepository : IRecipeRepository
{
    private readonly RecipeDbContext _context;

    public EFRecipeRepository(RecipeDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Recipe>> GetAllRecipes()
    {
        return await _context.Recipes.ToListAsync();
    }

    public async Task<Recipe?> GetRecipe(int recipeId)
    {
        return await _context.Recipes.SingleOrDefaultAsync(c => c.RecipeId == recipeId);
    }

    public async Task<Recipe?> GetOneUserRecipe(int userId, int recipeId)
    {
        return await _context.Recipes.SingleOrDefaultAsync(r => r.RecipeId == recipeId && r.UserId == userId);
    }

    public async Task<IEnumerable<Recipe>> GetAllUserRecipes(int userId)
    {
        return await _context.Recipes.Where(r => r.UserId == userId).ToListAsync();
    }

    public async Task<Recipe> CreateRecipe(Recipe newRecipe)
    {
        await _context.Recipes.AddAsync(newRecipe);
        await _context.SaveChangesAsync();
        return newRecipe;
    }

    public async Task<Recipe?> UpdateRecipe(int userId, Recipe updatedRecipe)
    {
        var originalRecipe = await _context.Recipes.SingleOrDefaultAsync(r => r.RecipeId == updatedRecipe.RecipeId && r.UserId == userId);
        if (originalRecipe != null)
        {
            originalRecipe.RecipeName = updatedRecipe.RecipeName;
            originalRecipe.RecipeCategory = updatedRecipe.RecipeCategory;
            originalRecipe.RecipeIngredients = updatedRecipe.RecipeIngredients;
            originalRecipe.RecipeInstructions = updatedRecipe.RecipeInstructions;
            originalRecipe.RecipeImgUrl = updatedRecipe.RecipeImgUrl;
            originalRecipe.UserId = updatedRecipe.UserId;

            await _context.SaveChangesAsync();
        }
        return originalRecipe;
    }

    public async Task DeleteRecipe(int userId, int recipeId)
    {
        var recipe = await _context.Recipes.SingleOrDefaultAsync(r => r.RecipeId == recipeId && r.UserId == userId);
        if (recipe != null)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Recipe>> SearchRecipes(string query)
    {
        return await _context.Recipes
        .Where(r => r.RecipeName.ToLower().Contains(query) || r.RecipeIngredients.ToLower().Contains(query) || r.RecipeCategory.ToLower().Contains(query))
        .ToListAsync();
    }
}