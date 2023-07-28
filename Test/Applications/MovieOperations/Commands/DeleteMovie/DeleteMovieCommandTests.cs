using Microsoft.EntityFrameworkCore;
using Moq;
using MovieStoreApi.Applications.MovieOperations.Commands.DeleteMovie;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandTests
    {
        private Mock<IMovieStoreDbContext> _mockDbContext;

        public DeleteMovieCommandTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
        }

        [Fact]
        public void WhenMovieDoesNotExist_ThrowsInvalidOperationException()
        {
            // Arrange
            var movieList = new List<Movie>
            {
                new Movie { ID = 1, Title = "Existing Movie" }
            };

            var dbSetMock = new Mock<DbSet<Movie>>();
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movieList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movieList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movieList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movieList.AsQueryable().GetEnumerator());

            _mockDbContext.Setup(x => x.Movies).Returns(dbSetMock.Object);

            var command = new DeleteMovieCommand(_mockDbContext.Object)
            {
                Id = 2 // this ID does not exist in our mock list
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }
    }
}
