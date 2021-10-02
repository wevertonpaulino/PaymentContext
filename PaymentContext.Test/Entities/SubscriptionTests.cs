using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.Entities
{
    public class SubscriptionTests
    {
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;

        public SubscriptionTests()
        {
            _document = new Document("36686774090", EDocumentType.CPF);
            _email = new Email("charliesheen@gmail.com");
            _address = new Address("Street 1", "1234", "District 1", "85875-000", "Malibu", "SP", "BR");
        }

        [Fact]
        public void ShouldReturnSuccessWhenSubscriptionIsValid()
        {
            // Arrange
            var subscription = new Subscription(DateTime.Now.AddDays(30));

            // Act and Assert
            Assert.True(subscription.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenSubscriptionIsInvalid()
        {
            // Arrange
            var subscription = new Subscription(DateTime.Now.AddDays(-1));

            // Act and Assert
            Assert.False(subscription.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenSubscriptionWithPixPaymentIsValid()
        {
            // Arrange
            var payment = new PixPayment(DateTime.Now, 40, 40, "Payer", _document, _email, _address, "5545999112233", EPixKeyType.PHONE_NUMBER);
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            subscription.AddPayment(payment);

            // Act and Assert
            Assert.True(subscription.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenSubscriptionWithPixPaymentIsInvalid()
        {
            // Arrange
            var payment = new PixPayment(DateTime.Now, 40, 35, null, _document, _email, _address, "999112233", EPixKeyType.PHONE_NUMBER);
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            subscription.AddPayment(payment);

            // Act and Assert
            Assert.False(subscription.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenSubscriptionWithCreditCardPaymentIsValid()
        {
            // Arrange
            var payment = new CreditCardPayment(DateTime.Now, 40, 40, "Payer", _document, _email, _address, "Holder Name", "5533340745760384", "1234");
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            subscription.AddPayment(payment);

            // Act and Assert
            Assert.True(subscription.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenSubscriptionWithCreditCardPaymentIsInvalid()
        {
            // Arrange
            var payment = new CreditCardPayment(DateTime.Now, 0, 40, null, _document, _email, _address, null, "0000000000000000", "1234");
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            subscription.AddPayment(payment);

            // Act and Assert
            Assert.False(subscription.IsValid);
        }
    }
}