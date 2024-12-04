using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace feastly_api;

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

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}