using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using MovieStoreApi.Applications.TokenOperations.CreateToken;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.TokenOperations
{
    public class CreateTokenCommandTests
    {
        [Fact]
        public void When_Valid_Credentials_Provided_Token_Is_Generated()
        {
            // Arrange
            var mockDbContext = new Mock<IMovieStoreDbContext>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            var customer = new Customer { Email = "test@email.com", Password = "testpass" };

            mockDbContext.Setup(db => db.Customers.FirstOrDefault(It.IsAny<Func<Customer, bool>>())).Returns(customer);

            var command = new CreateTokenCommand(mockDbContext.Object, mockMapper.Object, mockConfiguration.Object)
            {
                Model = new CreateTokenModel { Email = "test@email.com", Password = "testpass" }
            };

            // Act
            var token = command.Handle();

            // Assert
            Assert.NotNull(token);
            Assert.NotNull(token.RefreshToken);
        }

        [Fact]
        public void When_Invalid_Credentials_Provided_Throws_Exception()
        {
            // Arrange
            var mockDbContext = new Mock<IMovieStoreDbContext>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            mockDbContext.Setup(db => db.Customers.FirstOrDefault(It.IsAny<Func<Customer, bool>>())).Returns((Customer)null);

            var command = new CreateTokenCommand(mockDbContext.Object, mockMapper.Object, mockConfiguration.Object)
            {
                Model = new CreateTokenModel { Email = "invalid@email.com", Password = "invalidpass" }
            };

            // Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }
    }
}
