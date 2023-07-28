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
    public class GetByIdMovieQueryTests
    {
        private Mock<IMovieStoreDbContext> _mockDbContext;
        private Mock<IMapper> _mockMapper;

        public GetByIdMovieQueryTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void WhenMovieDoesNotExist_ThrowsInvalidOperationException()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie { ID = 1, Title = "Existing Movie", IsActive = true }
            };

            var dbSetMock = new Mock<DbSet<Movie>>();
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.AsQueryable().GetEnumerator());

            _mockDbContext.Setup(x => x.Movies).Returns(dbSetMock.Object);

            var query = new GetByIdMovieQuery(_mockDbContext.Object, _mockMapper.Object) { Id = 2 }; // Non-existent ID

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => query.Handle());
        }

        [Fact]
        public void WhenMovieExists_ReturnsMappedMovieDetailModel()
        {
            // Arrange
            var movie = new Movie { ID = 1, Title = "Existing Movie", IsActive = true, Genre = new Genre { Name = "Action" } };

            var movies = new List<Movie> { movie };

            var dbSetMock = new Mock<DbSet<Movie>>();
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.AsQueryable().GetEnumerator());

            _mockDbContext.Setup(x => x.Movies).Returns(dbSetMock.Object);

            var expectedModel = new MovieDetailModel { Title = "Existing Movie", Genre = "Action" };
            _mockMapper.Setup(m => m.Map<MovieDetailModel>(movie)).Returns(expectedModel);

            var query = new GetByIdMovieQuery(_mockDbContext.Object, _mockMapper.Object) { Id = 1 };

            // Act
            var result = query.Handle();

            // Assert
            Assert.Equal(expectedModel.Title, result.Title);
            Assert.Equal(expectedModel.Genre, result.Genre);
        }
    }
}
