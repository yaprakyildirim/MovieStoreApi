using AutoMapper;
using Moq;
using MovieStoreApi.Applications.ActorOperations.Commands.CreateActor;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandTests
    {
        private readonly Mock<IMovieStoreDbContext> _mockDbContext;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateActorModel _model;

        public CreateActorCommandTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
            _mockMapper = new Mock<IMapper>();
            _model = new CreateActorModel { FirstName = "John", LastName = "Doe" };
        }

        [Fact]
        public void WhenActorExists_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            var actor = new Actor { FirstName = _model.FirstName, LastName = _model.LastName };
            _mockDbContext.Setup(x => x.Actors.SingleOrDefault(It.IsAny<Func<Actor, bool>>())).Returns(actor);

            var command = new CreateActorCommand(_mockDbContext.Object, _mockMapper.Object)
            {
                Model = _model
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }

        [Fact]
        public void WhenActorDoesNotExists_ActorShouldBeAdded()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Actors.SingleOrDefault(It.IsAny<Func<Actor, bool>>())).Returns((Actor)null);
            _mockMapper.Setup(m => m.Map<Actor>(It.IsAny<CreateActorModel>())).Returns(new Actor());

            var command = new CreateActorCommand(_mockDbContext.Object, _mockMapper.Object)
            {
                Model = _model
            };

            // Act
            command.Handle();

            // Assert
            _mockDbContext.Verify(x => x.Actors.Add(It.IsAny<Actor>()), Times.Once);
            _mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
