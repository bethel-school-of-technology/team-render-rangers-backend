namespace feastly_api.Models;
public class Recipe {
    public int RecipeId { get; set; }
    public required string RecipeName { get; set; }
    public required string RecipeCategory { get; set; }
    public required string RecipeIngredients { get; set; }
    public required string RecipeInstructions { get; set; }
    public required string RecipeImgUrl { get; set; }
}