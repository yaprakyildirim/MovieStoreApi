using Moq;
using MovieStoreApi.Applications.DirectorOperations.Commands.DeleteDirector;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandTests
    {
        private readonly Mock<IMovieStoreDbContext> _mockDbContext;

        public DeleteDirectorCommandTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
        }

        [Fact]
        public void WhenDirectorIdDoesNotExist_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Directors.SingleOrDefault(It.IsAny<Func<Director, bool>>())).Returns((Director)null);

            var command = new DeleteDirectorCommand(_mockDbContext.Object)
            {
                DirectorId = 999  // An id that does not exist
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }

        [Fact]
        public void WhenDirectorIdExists_ShouldDeleteDirectorSuccessfully()
        {
            // Arrange
            var existingDirector = new Director { Id = 1, FirstName = "James", LastName = "Cameron" };
            _mockDbContext.Setup(x => x.Directors.SingleOrDefault(It.IsAny<Func<Director, bool>>())).Returns(existingDirector);

            var command = new DeleteDirectorCommand(_mockDbContext.Object)
            {
                DirectorId = 1  // An id that exists
            };

            // Act
            command.Handle();

            // Assert
            _mockDbContext.Verify(x => x.Directors.Remove(It.IsAny<Director>()), Times.Once);
            _mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
