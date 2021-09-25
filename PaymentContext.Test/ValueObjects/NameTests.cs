using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void ShouldReturnSuccessWhenNameIsValid()
        {
            // Arrange
            var name = new Name("Charlie", "Sheen");

            // Act and Assert
            Assert.True(name.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenNameIsInvalid()
        {
            // Arrange
            var name = new Name("", null);

            // Act and Assert
            Assert.False(name.IsValid);
        }
    }
}