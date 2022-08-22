using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class RepositoryDbContext : Microsoft.EntityFrameworkCore.DbContext
{

    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options, ServiceLifetime serviceLifetime) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /**
         * Generate ID.
         */
        modelBuilder.Entity<Movie>()
            .Property(movie => movie.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Review>()
            .Property(review => review.Id).ValueGeneratedOnUpdate();
        
        
        


    }

    public DbSet<Movie> MovieTable { get; set; }
    public DbSet<Review> ReviewTable { get; set; }
}