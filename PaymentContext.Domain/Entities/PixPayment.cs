using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PixPayment : Payment
    {
        public PixPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Email email, Address address, string key)
            : base(paidDate, expireDate, total, totalPaid, payer, document, email, address)
        {
            Key = key;
        }

        public string Key { get; private set; }
    }
}