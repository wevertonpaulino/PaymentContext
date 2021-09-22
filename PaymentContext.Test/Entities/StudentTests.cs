using System;
using PaymentContext.Domain.Entities;
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
            var student = new Student("Weverton", "Paulino", "12345678900", "wevertoncesar@gmail.com");
            student.AddSubscription(subscription);
        }
    }
}