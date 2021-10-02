using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Common.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Commands
{
    public class CreatePixPaymentSubscriptionCommand : Notifiable<Notification>, ICommand
    {
        // Student
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

        // PixPayment
        public string PixPaymentKey { get; set; }
        public EPixKeyType PixPaymentKeyType { get; set; }

        // Payment
        public Guid PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }

        // Address
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Name>()
                .Requires()
                .IsNotNullOrEmpty(FirstName, nameof(FirstName), $"{nameof(FirstName)} is null or empty")
                .IsNotNullOrEmpty(LastName, nameof(LastName), $"{nameof(LastName)} is null or empty")
            );
        }
    }
}