using System;
using System.Linq;
using DependencyResolver;
using MovieSample;
using MovieSample.Logging;

namespace PaymentProcessor.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create a new Dependency Injection Container
            var resolver = new Resolver();

            // Register dependencies
            resolver.Register<ILogger, DebugLogger>();
            resolver.Register<IMovieService, MovieService>();
            resolver.Register<IMovieRepository, MovieRepository>();

            // Resolve dependencies
            var movieService = resolver.Resolve<IMovieService>();

            var directorName = "Steven Spielberg";
            var moviesDirectedByStevenSpielberg = movieService.MoviesDirectedBy(directorName).ToList();
            Console.WriteLine($"Movies directed by {directorName}: {moviesDirectedByStevenSpielberg.Count}");

            foreach (var movie in moviesDirectedByStevenSpielberg)
            {
                Console.WriteLine($"Id={movie.Id}, Id={movie.Title}");
            }

            Console.ReadLine();
        }
    }
}