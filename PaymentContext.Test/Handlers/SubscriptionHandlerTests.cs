using System;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using Xunit;

namespace PaymentContext.Test.Handlers
{
    public class SubscriptionHandlerTests
    {
        [Fact]
        public void ShouldReturnSuccessWhenSubscriptionIsValid()
        {
            // Arrange
            var handler = new SubscriptionHandler();
            var command = new CreatePixPaymentSubscriptionCommand
            {
                FirstName = "Charlie",
                LastName = "Sheen",
                Document = "36686774090",
                Email = "charliesheen@gmail.com",
                PixPaymentKey = "5545999112233",
                PixPaymentKeyType = EPixKeyType.PHONE_NUMBER,
                PaymentNumber = Guid.NewGuid(),
                PaidDate = DateTime.Now,
                Total = 50,
                TotalPaid = 50,
                Payer = "Warner",
                PayerDocument = "36686774090",
                PayerDocumentType = EDocumentType.CPF,
                PayerEmail = "charliesheen@gmail.com",
                Street = "Street 1",
                Number = "1234",
                District = "District 1",
                ZipCode = "85875-000",
                City = "Malibu",
                State = "SP",
                Country = "BR",
            };

            // Act and Assert
            handler.Handle(command);
            Assert.True(handler.IsValid);
        }
    }
}