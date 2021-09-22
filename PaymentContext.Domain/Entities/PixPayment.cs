using System;

namespace PaymentContext.Domain.Entities
{
    public class PixPayment : Payment
    {
        public PixPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string email, string address, string key)
            : base(paidDate, expireDate, total, totalPaid, payer, document, email, address)
        {
            Key = key;
        }

        public string Key { get; private set; }
    }
}