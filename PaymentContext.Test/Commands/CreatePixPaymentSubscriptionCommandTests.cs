using PaymentContext.Domain.Commands;
using Xunit;

namespace PaymentContext.Test.Commands
{
    public class CreatePixPaymentSubscriptionCommandTests
    {
        [Fact]
        public void ShouldReturnSuccessWhenNameIsValid()
        {
            // Arrange
            var command = new CreatePixPaymentSubscriptionCommand();
            command.FirstName = "Weverton";
            command.LastName = "Paulino";

            // Act and Assert
            command.Validate();
            Assert.True(command.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenNameIsInvalid()
        {
            // Arrange
            var command = new CreatePixPaymentSubscriptionCommand();
            command.FirstName = "";
            command.LastName = null;

            // Act and Assert
            command.Validate();
            Assert.False(command.IsValid);
        }
    }
}