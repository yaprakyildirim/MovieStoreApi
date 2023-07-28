using Moq;
using MovieStoreApi.Applications.ActorOperations.Commands.DeleteActor;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandTests
    {
        private readonly Mock<IMovieStoreDbContext> _mockDbContext;

        public DeleteActorCommandTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
        }

        [Fact]
        public void WhenActorDoesNotExist_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Actors.SingleOrDefault(It.IsAny<Func<Actor, bool>>())).Returns((Actor)null);

            var command = new DeleteActorCommand(_mockDbContext.Object)
            {
                ActorId = 1
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }

        [Fact]
        public void WhenActorExists_ActorShouldBeRemoved()
        {
            // Arrange
            var actor = new Actor { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockDbContext.Setup(x => x.Actors.SingleOrDefault(It.IsAny<Func<Actor, bool>>())).Returns(actor);

            var command = new DeleteActorCommand(_mockDbContext.Object)
            {
                ActorId = 1
            };

            // Act
            command.Handle();

            // Assert
            _mockDbContext.Verify(x => x.Actors.Remove(It.IsAny<Actor>()), Times.Once);
            _mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
