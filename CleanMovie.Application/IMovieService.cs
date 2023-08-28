using System;
using CleanMovie.Domain;

namespace CleanMovie.Application
{
	public interface IMovieService
	{
		List<Movie> GetAllMovies();
		Movie CreateMovie(Movie movie);
	}
}

