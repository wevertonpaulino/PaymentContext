using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.ValueObjects
{
    public class AddressTests
    {
        [Fact]
        public void ShouldReturnSuccessWhenAddressIsValid()
        {
            // Arrange
            var address = new Address("Street 1", "1234", "Malibu", "85875-000", "California", "SP", "BR");

            // Act and Assert
            Assert.True(address.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenAddressIsInvalid()
        {
            // Arrange
            var address = new Address("Street 1", "1234", null, "85875000", "California", "TX", "BR");

            // Act and Assert
            Assert.False(address.IsValid);
        }
    }
}