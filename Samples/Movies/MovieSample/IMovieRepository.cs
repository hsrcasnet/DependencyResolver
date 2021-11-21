using System.Collections.Generic;
using MovieSample.Model;

namespace MovieSample
{
    /// <summary>
    /// Abstraction of all CRUD operations for movies.
    /// </summary>
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();

        Movie FindById(int movieId);

        Movie CreateMovie(Movie newMovie);

        void UpdateMovie(int movieId, Movie updatedMovie);

        void DeleteMovie(int movieId);
    }
}