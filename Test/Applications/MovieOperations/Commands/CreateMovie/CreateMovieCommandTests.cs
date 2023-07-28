using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using MovieStoreApi.Applications.MovieOperations.Commands.CreateMovie;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandTests
    {
        private Mock<IMovieStoreDbContext> _mockDbContext;
        private Mock<IMapper> _mockMapper;

        public CreateMovieCommandTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void WhenMovieAlreadyExists_ThrowsInvalidOperationException()
        {
            // Arrange
            var movieList = new List<Movie>
            {
                new Movie { Title = "Existing Movie" }
            };

            var dbSetMock = new Mock<DbSet<Movie>>();
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movieList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movieList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movieList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movieList.AsQueryable().GetEnumerator());

            _mockDbContext.Setup(x => x.Movies).Returns(dbSetMock.Object);

            var command = new CreateMovieCommand(_mockDbContext.Object, _mockMapper.Object)
            {
                Model = new CreateMovieModel
                {
                    Title = "Existing Movie"
                }
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }
    }
}
