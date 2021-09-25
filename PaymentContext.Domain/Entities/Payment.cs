using System;
using Flunt.Extensions.Br.Validations;
using Flunt.Validations;
using PaymentContext.Common.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, decimal total, decimal totalPaid, string payer, Document document, Email email, Address address)
        {
            Number = Guid.NewGuid();
            PaidDate = paidDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Email = email;
            Address = address;

            AddNotifications(new Contract<Payment>()
                .Requires()
                .IsGreaterThan(Total, 0, nameof(Total), $"{nameof(Total)} must be greater than 0")
                .IsGreaterOrEqualsThan(TotalPaid, Total, nameof(TotalPaid), $"{nameof(TotalPaid)} must be greater than or equal to {nameof(Total)}"),
            Document, Email, Address);
        }

        public Guid Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
    }
}