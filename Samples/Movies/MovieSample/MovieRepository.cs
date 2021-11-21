using System.Collections.Generic;
using System.Linq;
using MovieSample.Model;

namespace MovieSample
{
    public class MovieRepository : IMovieRepository
    {
        private int idCounter = 0;
        private readonly ILogger logger;
        private readonly List<Movie> movies;

        public MovieRepository(ILogger logger)
        {
            this.logger = logger;

            this.movies = new List<Movie>();
            this.CreateMovie(new Movie { Title = "E.T.", Director = "Steven Spielberg" });
            this.CreateMovie(new Movie { Title = "Schindler's List", Director = "Steven Spielberg" });
            this.CreateMovie(new Movie { Title = "Jurassic Park", Director = "Steven Spielberg" });
            this.CreateMovie(new Movie { Title = "Star Wars", Director = "George Lucas" });
            this.CreateMovie(new Movie { Title = "Pulp Fiction", Director = "Quentin Tarantino" });
            this.CreateMovie(new Movie { Title = "Inglorious Bastards", Director = "Quentin Tarantino" });
        }

        public Movie CreateMovie(Movie movie)
        {
            movie.Id = ++this.idCounter;
            this.movies.Add(movie);

            this.logger.Log($"CreateMovie: {movie.Title}");
            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.movies;
        }

        public Movie FindById(int movieId)
        {
            return this.movies.FirstOrDefault(m => m.Id == movieId);
        }

        public void DeleteMovie(int movieId)
        {
            var existingMovie = this.FindById(movieId);
            if (existingMovie != null)
            {
                this.movies.Remove(existingMovie);
            }
        }

        public void UpdateMovie(int movieId, Movie movie)
        {
            var existingMovie = this.FindById(movieId);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Director = movie.Director;
            }
        }
    }
}