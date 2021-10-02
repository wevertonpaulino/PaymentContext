using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.Entities
{
    public class StudentTests
    {
        private Student BuildValidStudent()
        {
            var name = new Name("Charlie", "Sheen");
            var document = new Document("36686774090", EDocumentType.CPF);
            var email = new Email("charliesheen@gmail.com");
            var address = new Address("Street 1", "1234", "District 1", "85875-000", "Malibu", "SP", "BR");

            return new Student(name, document, email, address);
        }

        private Student BuildInvalidStudent()
        {
            var name = new Name("", null);
            var document = new Document("00000000000", EDocumentType.CPF);
            var email = new Email("charliesheengmail.com");
            var address = new Address("Street 1", "1234", null, "85875000", "Malibu", null, "XX");

            return new Student(name, document, email, address);
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
            var student = BuildInvalidStudent();
            student.AddSubscription(subscription);

            // Act and Assert
            Assert.False(student.IsValid);
        }
    }
}