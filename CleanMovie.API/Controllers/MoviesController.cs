using System;
using CleanMovie.Application;
using CleanMovie.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API
{

	// route
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController: ControllerBase
	{
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
		{
            _movieService = movieService;
        }

		[HttpGet]
		public ActionResult<List<Movie>> GetAll()
		{
			var moviesFromService = _movieService.GetAllMovies().ToList();

            return Ok(moviesFromService);
		}

		[HttpPost]
		public ActionResult<Movie> CreateMovie(Movie movie)
		{
			var new_movie = _movieService.CreateMovie(movie);
			return new_movie;
		}

	}
}

