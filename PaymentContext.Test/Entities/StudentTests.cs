using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.Entities
{
    public class StudentTests
    {
        private Name BuildValidName() => new Name("Charlie", "Sheen");

        private Name BuildInvalidName() => new Name("", null);

        private Document BuildValidDocument() => new Document("36686774090", EDocumentType.CPF);

        private Document BuildInvalidDocument() => new Document("00000000000", EDocumentType.CPF);

        private Email BuildValidEmail() => new Email("charliesheen@gmail.com");

        private Email BuildInvalidEmail() => new Email("charliesheengmail.com");

        private Address BuildValidAddress() => new Address("Street 1", "1234", "Malibu", "85875-000", "California", "SP", "BR");

        private Address BuildInvalidAddress() => new Address("Street 1", "1234", null, "85875000", "California", "TX", "BR");

        private Student BuildValidStudent()
        {
            var name = BuildValidName();
            var document = BuildValidDocument();
            var email = BuildValidEmail();
            var address = BuildValidAddress();

            return new Student(name, document, email, address);
        }

        private Student BuildInvalidStudent()
        {
            var name = BuildInvalidName();
            var document = BuildInvalidDocument();
            var email = BuildInvalidEmail();
            var address = BuildInvalidAddress();

            return new Student(name, document, email, address);
        }

        private Payment BuildValidPixPayment()
        {
            var document = BuildValidDocument();
            var email = BuildValidEmail();
            var address = BuildValidAddress();

            return new PixPayment(DateTime.Now, 40, 40, "Payer", document, email, address, "5545999385030", EPixKeyType.PHONE_NUMBER);
        }

        private Payment BuildInvalidPixPayment()
        {
            var document = BuildInvalidDocument();
            var email = BuildInvalidEmail();
            var address = BuildInvalidAddress();

            return new PixPayment(DateTime.Now, 40, 40, "Payer", document, email, address, "5545999385030", EPixKeyType.PHONE_NUMBER);
        }

        private Payment BuildValidCreditCardPayment()
        {
            var document = BuildValidDocument();
            var email = BuildValidEmail();
            var address = BuildValidAddress();

            return new CreditCardPayment(DateTime.Now, 40, 40, "Payer", document, email, address, "Holder Name", "5533340745760384", "1234");
        }

        private Payment BuildInvalidCreditCardPayment()
        {
            var document = BuildInvalidDocument();
            var email = BuildInvalidEmail();
            var address = BuildInvalidAddress();

            return new CreditCardPayment(DateTime.Now, 40, 40, "Payer", document, email, address, "Holder Name", "5533340745760384", "1234");
        }

        [Fact]
        public void ShouldReturnSuccessWhenNameIsValid()
        {
            // Arrange
            var name = BuildValidName();

            // Act and Assert
            Assert.True(name.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenNameIsInvalid()
        {
            // Arrange
            var name = BuildInvalidName();

            // Act and Assert
            Assert.False(name.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenDocumentIsValid()
        {
            // Arrange
            var document = BuildValidDocument();

            // Act and Assert
            Assert.True(document.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenDocumentIsInvalid()
        {
            // Arrange
            var document = BuildInvalidDocument();

            // Act and Assert
            Assert.False(document.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenEmailIsValid()
        {
            // Arrange
            var email = BuildValidEmail();

            // Act and Assert
            Assert.True(email.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenEmailIsInvalid()
        {
            // Arrange
            var email = BuildInvalidEmail();

            // Act and Assert
            Assert.False(email.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenAddressIsValid()
        {
            // Arrange
            var address = BuildValidAddress();

            // Act and Assert
            Assert.True(address.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenAddressIsInvalid()
        {
            // Arrange
            var address = BuildInvalidAddress();

            // Act and Assert
            Assert.False(address.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenStudentIsValid()
        {
            // Arrange
            var student = BuildValidStudent();

            // Act and Assert
            Assert.True(student.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenStudentIsInvalid()
        {
            // Arrange
            var student = BuildInvalidStudent();

            // Act and Assert
            Assert.False(student.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenPixPaymentIsValid()
        {
            // Arrange
            var payment = BuildValidPixPayment();

            // Act and Assert
            Assert.True(payment.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenPixPaymentIsInvalid()
        {
            // Arrange
            var payment = BuildInvalidPixPayment();

            // Act and Assert
            Assert.False(payment.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenCreditCardPaymentIsValid()
        {
            // Arrange
            var payment = BuildValidCreditCardPayment();

            // Act and Assert
            Assert.True(payment.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenCreditCardPaymentIsInvalid()
        {
            // Arrange
            var payment = BuildInvalidCreditCardPayment();

            // Act and Assert
            Assert.False(payment.IsValid);
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
            var payment = BuildValidPixPayment();
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            subscription.AddPayment(payment);

            // Act and Assert
            Assert.True(subscription.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenSubscriptionWithPixPaymentIsInvalid()
        {
            // Arrange
            var payment = BuildInvalidPixPayment();
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            subscription.AddPayment(payment);

            // Act and Assert
            Assert.False(subscription.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenSubscriptionWithCreditCardPaymentIsValid()
        {
            // Arrange
            var payment = BuildValidCreditCardPayment();
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            subscription.AddPayment(payment);

            // Act and Assert
            Assert.True(subscription.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenSubscriptionWithCreditCardPaymentIsInvalid()
        {
            // Arrange
            var payment = BuildInvalidCreditCardPayment();
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            subscription.AddPayment(payment);

            // Act and Assert
            Assert.False(subscription.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenStudentWithSubscriptionIsValid()
        {
            // Arrange
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            var student = BuildValidStudent();
            student.AddSubscription(subscription);

            // Act and Assert
            Assert.True(student.IsValid);
        }

        [Fact]
        public void ShouldReturnFailureWhenStudentWithSubscriptionIsInvalid()
        {
            // Arrange
            var subscription = new Subscription(DateTime.Now.AddDays(-1));
            var student = BuildValidStudent();
            student.AddSubscription(subscription);

            // Act and Assert
            Assert.False(student.IsValid);
        }
    }
}