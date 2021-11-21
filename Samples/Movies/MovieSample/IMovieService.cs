using System.Collections.Generic;
using MovieSample.Model;

namespace MovieSample
{
    /// <summary>
    /// Abstraction of the movie business logic.
    /// </summary>
    public interface IMovieService
    {
        Movie CreateMovie(string director, string title);

        IEnumerable<Movie> MoviesDirectedBy(string director);
    }
}