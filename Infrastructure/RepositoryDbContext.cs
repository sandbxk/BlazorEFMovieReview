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
        /*** Generate ID.    */
        modelBuilder.Entity<Movie>()
            .Property(movie => movie.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Review>()
            .Property(review => review.Id).ValueGeneratedOnAdd();

        // Primary Key
        modelBuilder.Entity<Movie>().HasKey(movie => movie.Id);
        modelBuilder.Entity<Review>().HasKey(review => review.Id);

/*
        modelBuilder.Entity<Movie>()
            .HasMany<Review>(r => r.Reviews)
            .WithOne(review => review.Movie)
            .HasForeignKey(review => review.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
            */

        modelBuilder.Entity<Review>()
            .HasOne<Movie>(review => review.Movie)
            .WithMany(movie => movie.Reviews)
            .HasForeignKey(review => review.MovieId);






    }

    public DbSet<Movie> MovieTable { get; set; }
    public DbSet<Review> ReviewTable { get; set; }
}