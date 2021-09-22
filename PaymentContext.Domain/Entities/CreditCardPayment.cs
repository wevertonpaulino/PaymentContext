using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string email, string address, string cardHolderName, string cardNumber, string lastTransactionNumber)
            : base(paidDate, expireDate, total, totalPaid, payer, document, email, address)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}