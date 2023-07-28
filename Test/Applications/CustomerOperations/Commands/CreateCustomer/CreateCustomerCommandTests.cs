using AutoMapper;
using Moq;
using MovieStoreApi.Applications.CustomerOperations.Commands.CreateCustomer;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandTests
    {
        private readonly Mock<IMovieStoreDbContext> _mockDbContext;
        private readonly Mock<IMapper> _mockMapper;

        public CreateCustomerCommandTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void WhenCustomerEmailExists_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            var existingCustomer = new Customer { Email = "existing@email.com" };
            _mockDbContext.Setup(x => x.Customers.SingleOrDefault(It.IsAny<Func<Customer, bool>>())).Returns(existingCustomer);

            var command = new CreateCustomerCommand(_mockDbContext.Object, _mockMapper.Object)
            {
                Model = new CreateCustomerModel { Email = "existing@email.com" }
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }

        [Fact]
        public void WhenCustomerEmailDoesNotExists_ShouldAddCustomerSuccessfully()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Customers.SingleOrDefault(It.IsAny<Func<Customer, bool>>())).Returns((Customer)null);

            var newCustomer = new Customer { Email = "new@email.com" };
            _mockMapper.Setup(m => m.Map<Customer>(It.IsAny<CreateCustomerModel>())).Returns(newCustomer);

            var command = new CreateCustomerCommand(_mockDbContext.Object, _mockMapper.Object)
            {
                Model = new CreateCustomerModel { Email = "new@email.com" }
            };

            // Act
            command.Handle();

            // Assert
            _mockDbContext.Verify(x => x.Customers.Add(It.IsAny<Customer>()), Times.Once);
            _mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
