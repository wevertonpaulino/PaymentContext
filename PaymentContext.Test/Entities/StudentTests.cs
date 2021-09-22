using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.Entities
{
    public class StudentTests
    {
        [Fact]
        public void TestMethod1()
        {
            var expireDate = new DateTime(31, 12, 2021);
            var subscription = new Subscription(expireDate);
            var name = new Name("Weverton", "Paulino");
            var document = new Document("12345678900", EDocumentType.CPF);
            var email = new Email("wevertoncesar@gmail.com");
            var student = new Student(name, document, email);
            student.AddSubscription(subscription);
        }
    }
}