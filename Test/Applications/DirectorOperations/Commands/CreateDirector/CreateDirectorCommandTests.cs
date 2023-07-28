using AutoMapper;
using Moq;
using MovieStoreApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandTests
    {
        private readonly Mock<IMovieStoreDbContext> _mockDbContext;
        private readonly Mock<IMapper> _mockMapper;

        public CreateDirectorCommandTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void WhenDirectorNameExists_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            var existingDirector = new Director { FirstName = "James", LastName = "Cameron" };
            _mockDbContext.Setup(x => x.Directors.SingleOrDefault(It.IsAny<Func<Director, bool>>())).Returns(existingDirector);

            var command = new CreateDirectorCommand(_mockDbContext.Object, _mockMapper.Object)
            {
                Model = new CreateDirectorModel { FirstName = "James", LastName = "Cameron" }
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }

        [Fact]
        public void WhenDirectorNameDoesNotExists_ShouldAddDirectorSuccessfully()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Directors.SingleOrDefault(It.IsAny<Func<Director, bool>>())).Returns((Director)null);

            var newDirector = new Director { FirstName = "Steven", LastName = "Spielberg" };
            _mockMapper.Setup(m => m.Map<Director>(It.IsAny<CreateDirectorModel>())).Returns(newDirector);

            var command = new CreateDirectorCommand(_mockDbContext.Object, _mockMapper.Object)
            {
                Model = new CreateDirectorModel { FirstName = "Steven", LastName = "Spielberg" }
            };

            // Act
            command.Handle();

            // Assert
            _mockDbContext.Verify(x => x.Directors.Add(It.IsAny<Director>()), Times.Once);
            _mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
