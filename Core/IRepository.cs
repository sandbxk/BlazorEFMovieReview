namespace Entities;

public interface IRepository
{
    List<Review> GetReviews();

    List<Movie> GetMovies();
    Movie DeleteMovie(int movieId);
    Review DeleteReview(int reviewId); 
    Movie AddMovie(Movie movie);
    Review AddReview(Review review);
}
