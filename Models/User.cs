using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace feastly_api.Models;

public class User
{
    [JsonIgnore]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Please enter your name")]
    public required string Name { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

    // public string? token { get; set; }

    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>(); 
}