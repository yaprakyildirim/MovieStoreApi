using AutoMapper;
using Moq;
using MovieStoreApi.Applications.DirectorOperations.Commands.UpdateDirector;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandTests
    {
        private readonly Mock<IMovieStoreDbContext> _mockDbContext;
        private readonly Mock<IMapper> _mockMapper;

        public UpdateDirectorCommandTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void WhenDirectorIdDoesNotExist_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Directors.SingleOrDefault(It.IsAny<Func<Director, bool>>())).Returns((Director)null);

            var command = new UpdateDirectorCommand(_mockDbContext.Object, _mockMapper.Object)
            {
                GenreID = 999  // An id that does not exist
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }

        [Fact]
        public void WhenDirectorIdExists_ShouldUpdateDirectorSuccessfully()
        {
            // Arrange
            var existingDirector = new Director { Id = 1, FirstName = "James", LastName = "Cameron" };
            _mockDbContext.Setup(x => x.Directors.SingleOrDefault(It.IsAny<Func<Director, bool>>())).Returns(existingDirector);
            _mockMapper.Setup(m => m.Map<UpdateDirectorModel, Director>(It.IsAny<UpdateDirectorModel>(), It.IsAny<Director>())).Callback<UpdateDirectorModel, Director>((src, dest) => dest.FirstName = src.FirstName);

            var command = new UpdateDirectorCommand(_mockDbContext.Object, _mockMapper.Object)
            {
                GenreID = 1,  // An id that exists
                Model = new UpdateDirectorModel { FirstName = "John", LastName = "Smith" }
            };

            // Act
            command.Handle();

            // Assert
            Assert.Equal("John", existingDirector.FirstName);
            _mockDbContext.Verify(x => x.Directors.Update(It.IsAny<Director>()), Times.Once);
            _mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
