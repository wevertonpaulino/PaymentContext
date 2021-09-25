using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void ShouldReturnSuccessWhenEmailIsValid()
        {
            // Arrange
            var email = new Email("charliesheen@gmail.com");

            // Act and Assert
            Assert.True(email.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenEmailIsInvalid()
        {
            // Arrange
            var email = new Email("charliesheengmail.com");

            // Act and Assert
            Assert.False(email.IsValid);
        }
    }
}