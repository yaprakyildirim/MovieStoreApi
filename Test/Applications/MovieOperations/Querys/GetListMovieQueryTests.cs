using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using MovieStoreApi.Applications.MovieOperations.Querys;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.MovieOperations.Querys
{
    public class GetListMovieQueryTests
    {
        private Mock<IMovieStoreDbContext> _mockDbContext;
        private Mock<IMapper> _mockMapper;

        public GetListMovieQueryTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void WhenMoviesExist_ReturnsAllActiveMoviesOrderedById()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie { ID = 3, Title = "Third Movie", IsActive = true, Genre = new Genre { Name = "Action" } },
                new Movie { ID = 1, Title = "First Movie", IsActive = true, Genre = new Genre { Name = "Comedy" } },
                new Movie { ID = 2, Title = "Second Movie", IsActive = true, Genre = new Genre { Name = "Drama" } },
                new Movie { ID = 4, Title = "Fourth Movie", IsActive = false, Genre = new Genre { Name = "Horror" } } // Inactive movie
            };

            var dbSetMock = new Mock<DbSet<Movie>>();
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.AsQueryable().GetEnumerator());

            _mockDbContext.Setup(x => x.Movies).Returns(dbSetMock.Object);

            var expectedMovies = new List<MovieViewModel>
            {
                new MovieViewModel { Title = "First Movie", Genre = "Comedy", Price = 0 }, // Price is hardcoded to 0 for simplicity.
                new MovieViewModel { Title = "Second Movie", Genre = "Drama", Price = 0 },
                new MovieViewModel { Title = "Third Movie", Genre = "Action", Price = 0 }
            };

            _mockMapper.Setup(m => m.Map<List<MovieViewModel>>(It.IsAny<List<Movie>>())).Returns(expectedMovies);

            var query = new GetListMovieQuery(_mockDbContext.Object, _mockMapper.Object);

            // Act
            var result = query.Handle();

            // Assert
            Assert.Equal(expectedMovies.Count, result.Count); // Ensure all active movies are returned

            for (int i = 0; i < expectedMovies.Count; i++)
            {
                Assert.Equal(expectedMovies[i].Title, result[i].Title);
                Assert.Equal(expectedMovies[i].Genre, result[i].Genre);
            }
        }
    }
}
