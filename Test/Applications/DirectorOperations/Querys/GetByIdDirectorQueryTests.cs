using AutoMapper;
using Moq;
using MovieStoreApi.Applications.DirectorOperations.Queries;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.DirectorOperations.Querys
{
    public class GetByIdDirectorQueryTests
    {
        private readonly Mock<IMovieStoreDbContext> _mockDbContext;
        private readonly Mock<IMapper> _mockMapper;

        public GetByIdDirectorQueryTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void WhenDirectorIdDoesNotExist_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Directors.SingleOrDefault(It.IsAny<Func<Director, bool>>())).Returns((Director)null);

            var query = new GetByIdDirectorQuery(_mockDbContext.Object, _mockMapper.Object)
            {
                DirectorId = 999  // An id that does not exist
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => query.Handle());
        }

        [Fact]
        public void WhenDirectorIdExists_ShouldReturnDirectorModelSuccessfully()
        {
            // Arrange
            var existingDirector = new Director { Id = 1, FirstName = "James", LastName = "Cameron" };
            _mockDbContext.Setup(x => x.Directors.SingleOrDefault(It.IsAny<Func<Director, bool>>())).Returns(existingDirector);
            _mockMapper.Setup(m => m.Map<GetByIdDirectorModel>(It.IsAny<Director>())).Returns(new GetByIdDirectorModel { FirstName = "James", LastName = "Cameron" });

            var query = new GetByIdDirectorQuery(_mockDbContext.Object, _mockMapper.Object)
            {
                DirectorId = 1  // An id that exists
            };

            // Act
            var result = query.Handle();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("James", result.FirstName);
            Assert.Equal("Cameron", result.LastName);
        }
    }
}
