﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure;

public class Repository :  IRepository
{

    private Movie mockMovieObject;
    private Review mockReviewObject;
    private DbContextOptions<RepositoryDbContext> _opts;

    public Repository()
    {
        mockMovieObject = new Movie()
        {
            Id = 1, Summary = "Bob writes a program ...", Title = "Bob's Movie", ReleaseYear = 2022,
            BoxOfficeSumInMillions = 42
        };
        mockReviewObject = new Review()
        {
            Id = 1, Headline = "Super great movie", Rating = 5,
            ReviewerName = "Smølf", MovieId = 1, Movie = mockMovieObject
        };

        _opts = new DbContextOptionsBuilder<RepositoryDbContext>()
            .UseSqlite("Data source=..//GUI/db.db").Options;
    }

    public List<Review> GetReviews()
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            return context.ReviewTable.Include(review => review.Movie).ToList();
        }
    }

    public List<Movie> GetMovies()
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            return context.MovieTable.Include(movie => movie.Reviews).ToList();
        }
    }

    public Movie DeleteMovie(int movieId)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            var movie = context.MovieTable.Find(movieId);
            context.Remove(movie);
            context.SaveChanges();
            return movie ?? mockMovieObject;
        }
    }

    public Review DeleteReview(int reviewId)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            var r = context.ReviewTable.Find(reviewId);
            context.Remove(r);
            context.SaveChanges();
            return r ?? mockReviewObject;
        }
    }

    public Movie AddMovie(Movie movie)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            context.MovieTable.Add(movie);
            context.SaveChanges();
            return movie;
        }
    }

    public Review AddReview(Review review)
    {
        using (var context = new RepositoryDbContext(_opts, ServiceLifetime.Scoped))
        {
            var m = context.MovieTable.Find(review.MovieId) ?? throw new InvalidOperationException();
            review.Movie = m;
            context.ReviewTable.Add(review);
            context.SaveChanges();
            return review;
        }
    }
}