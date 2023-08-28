using CleanMovie.Application;
using CleanMovie.Domain;

namespace CleanMovie.Infrastructure;

public class MovieRepository : IMovieRepository
{
    //public static List<Movie> movies = new List<Movie>() {
    //       new Movie {Id= 1, Name="shamba", Cost =2 },
    //};

    private readonly MovieDbContext _movieDbContext;

    public MovieRepository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }

    public Movie CreateMovie(Movie movie)
    {
         _movieDbContext.Add(movie);  // just add 
        _movieDbContext.SaveChanges(); //persist in database
        return movie;
    }

    public List<Movie> GetAllMovies()
    {
        return _movieDbContext.Movies.ToList();
    }
}

