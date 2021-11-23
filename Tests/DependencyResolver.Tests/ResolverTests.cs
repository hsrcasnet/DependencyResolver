using System;
using FluentAssertions;
using MovieSample;
using MovieSample.Logging;
using Xunit;

namespace DependencyResolver.Tests
{
    public class ResolverTests
    {
        [Fact]
        public void ShouldRegisterAndResolveService()
        {
            // Arrange
            var resolver = new Resolver();
            resolver.Register<ILogger, DebugLogger>();
            resolver.Register<IMovieRepository, MovieRepository>();

            // Act
            var movieRepository = resolver.Resolve<IMovieRepository>();

            // Assert
            movieRepository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldResolve_ThrowsExceptionIfMissingRegistration()
        {
            // Arrange
            var resolver = new Resolver();

            // Act
            Action action = () => resolver.Resolve<IMovieRepository>();

            // Assert
            action.Should().Throw<Exception>().WithMessage("Could not resolve MovieSample.IMovieRepository");
        }
    }
}
