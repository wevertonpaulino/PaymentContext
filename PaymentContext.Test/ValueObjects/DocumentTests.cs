using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.ValueObjects
{
    public class DocumentTests
    {
        [Fact]
        public void ShouldReturnSuccessWhenDocumentIsValid()
        {
            // Arrange
            var document = new Document("36686774090", EDocumentType.CPF);

            // Act and Assert
            Assert.True(document.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenDocumentIsInvalid()
        {
            // Arrange
            var document = new Document("00000000000", EDocumentType.CPF);

            // Act and Assert
            Assert.False(document.IsValid);
        }
    }
}