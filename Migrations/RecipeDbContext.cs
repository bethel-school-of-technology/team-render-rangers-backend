using feastly_api.Models;
using Microsoft.EntityFrameworkCore;

namespace feastly_api.Migrations;

public class RecipeDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.Name).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Password).IsRequired();
        });
    }
}

