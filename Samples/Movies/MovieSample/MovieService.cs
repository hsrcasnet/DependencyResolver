using System.Collections.Generic;
using System.Linq;
using MovieSample.Model;

namespace MovieSample
{
    public class MovieService : IMovieService
    {
        private readonly ILogger logger;
        private readonly IMovieRepository movieRepsitory;

        public MovieService(ILogger logger, IMovieRepository movieRepsitory)
        {
            this.logger = logger;
            this.movieRepsitory = movieRepsitory;
        }

        public IEnumerable<Movie> MoviesDirectedBy(string director)
        {
            this.logger.Log("MovieService: MoviesDirectedBy");
            var moviesDirectedBy = this.movieRepsitory.GetAll().Where(m => m.Director == director);
            return moviesDirectedBy;
        }

        public Movie CreateMovie(string director, string title)
        {
            this.logger.Log("MovieService: CreateMovie");
            var movie = new Movie { Title = title, Director = director };
            var createdMovie = this.movieRepsitory.CreateMovie(movie);
            return createdMovie;
        }
    }
}
