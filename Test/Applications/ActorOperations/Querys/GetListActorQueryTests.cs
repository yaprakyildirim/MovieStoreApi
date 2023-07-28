using AutoMapper;
using Moq;
using MovieStoreApi.Applications.ActorOperations.Querys;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.ActorOperations.Querys
{
    public class GetListActorQueryTests
    {
        private readonly Mock<IMovieStoreDbContext> _mockDbContext;
        private readonly Mock<IMapper> _mockMapper;
        private readonly List<Actor> _fakeActors;

        public GetListActorQueryTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
            _mockMapper = new Mock<IMapper>();

            _fakeActors = new List<Actor>
            {
                new Actor { Id = 1, FirstName = "John", LastName = "Doe", IsAvtive = true },
                new Actor { Id = 2, FirstName = "Jane", LastName = "Doe", IsAvtive = true }
            };
        }

        [Fact]
        public void WhenActorsAreActive_ShouldReturnActorList()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Actors.Where(It.IsAny<System.Func<Actor, bool>>())).Returns(_fakeActors.AsQueryable());
            _mockMapper.Setup(m => m.Map<List<GetListActorModel>>(It.IsAny<List<Actor>>())).Returns(new List<GetListActorModel>());

            var query = new GetListActorQuery(_mockDbContext.Object, _mockMapper.Object);

            // Act
            var result = query.Handle();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(_fakeActors.Count, result.Count);
        }

        [Fact]
        public void ActorsShouldBeMappedToModelCorrectly()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Actors.Where(It.IsAny<System.Func<Actor, bool>>())).Returns(_fakeActors.AsQueryable());

            var expectedModelList = new List<GetListActorModel>
            {
                new GetListActorModel { FirstName = "John", LastName = "Doe" },
                new GetListActorModel { FirstName = "Jane", LastName = "Doe" }
            };

            _mockMapper.Setup(m => m.Map<List<GetListActorModel>>(It.IsAny<List<Actor>>())).Returns(expectedModelList);

            var query = new GetListActorQuery(_mockDbContext.Object, _mockMapper.Object);

            // Act
            var result = query.Handle();

            // Assert
            Assert.Equal(expectedModelList[0].FirstName, result[0].FirstName);
            Assert.Equal(expectedModelList[0].LastName, result[0].LastName);
            Assert.Equal(expectedModelList[1].FirstName, result[1].FirstName);
            Assert.Equal(expectedModelList[1].LastName, result[1].LastName);
        }
    }
}
