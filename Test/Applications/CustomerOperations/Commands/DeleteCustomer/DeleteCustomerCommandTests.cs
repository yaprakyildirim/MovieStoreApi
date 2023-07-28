using Moq;
using MovieStoreApi.Applications.CustomerOperations.Commands.DeleteCustomer;
using MovieStoreApi.DbOperations;
using MovieStoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreApi.Test.Applications.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandTests
    {
        private readonly Mock<IMovieStoreDbContext> _mockDbContext;

        public DeleteCustomerCommandTests()
        {
            _mockDbContext = new Mock<IMovieStoreDbContext>();
        }

        [Fact]
        public void WhenCustomerIdDoesNotExist_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            _mockDbContext.Setup(x => x.Customers.SingleOrDefault(It.IsAny<Func<Customer, bool>>())).Returns((Customer)null);

            var command = new DeleteCustomerCommand(_mockDbContext.Object)
            {
                CustomerId = 999  // An id that does not exist
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => command.Handle());
        }

        [Fact]
        public void WhenCustomerIdExists_ShouldDeleteCustomerSuccessfully()
        {
            // Arrange
            var existingCustomer = new Customer { Id = 1, Email = "existing@email.com" };
            _mockDbContext.Setup(x => x.Customers.SingleOrDefault(It.IsAny<Func<Customer, bool>>())).Returns(existingCustomer);

            var command = new DeleteCustomerCommand(_mockDbContext.Object)
            {
                CustomerId = 1  // An id that exists
            };

            // Act
            command.Handle();

            // Assert
            _mockDbContext.Verify(x => x.Customers.Remove(It.IsAny<Customer>()), Times.Once);
            _mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
