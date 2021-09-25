using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.Entities
{
    public class PaymentTests
    {
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;

        public PaymentTests()
        {
            _document = new Document("36686774090", EDocumentType.CPF);
            _email = new Email("charliesheen@gmail.com");
            _address = new Address("Street 1", "1234", "Malibu", "85875-000", "California", "SP", "BR");
        }

        [Fact]
        public void ShouldReturnSuccessWhenPixPaymentIsValid()
        {
            // Arrange
            var payment = new PixPayment(DateTime.Now, 40, 40, "Payer", _document, _email, _address, "5545999112233", EPixKeyType.PHONE_NUMBER);

            // Act and Assert
            Assert.True(payment.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenPixPaymentIsInvalid()
        {
            // Arrange
            var payment = new PixPayment(DateTime.Now, 40, 35, null, _document, _email, _address, "999112233", EPixKeyType.PHONE_NUMBER);

            // Act and Assert
            Assert.False(payment.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenCreditCardPaymentIsValid()
        {
            // Arrange
            var payment = new CreditCardPayment(DateTime.Now, 40, 40, "Payer", _document, _email, _address, "Holder Name", "5533340745760384", "1234");

            // Act and Assert
            Assert.True(payment.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenCreditCardPaymentIsInvalid()
        {
            // Arrange
            var payment = new CreditCardPayment(DateTime.Now, 0, 40, null, _document, _email, _address, null, "0000000000000000", "1234");

            // Act and Assert
            Assert.False(payment.IsValid);
        }
    }
}