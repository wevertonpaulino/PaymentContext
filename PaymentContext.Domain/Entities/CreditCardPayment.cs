using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(DateTime paidDate, decimal total, decimal totalPaid, string payer, Document document, Email email, Address address, string cardHolderName, string cardNumber, string lastTransactionNumber)
            : base(paidDate, total, totalPaid, payer, document, email, address)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;

            AddNotifications(new Contract<CreditCardPayment>()
                .Requires()
                .IsNotNullOrEmpty(CardHolderName, nameof(CardHolderName), $"{nameof(CardHolderName)} is null or empty")
                .IsCreditCard(CardNumber, nameof(CardNumber), $"{nameof(CardNumber)} is invalid")
            );
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}