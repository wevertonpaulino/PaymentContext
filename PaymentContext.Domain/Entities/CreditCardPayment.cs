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
                .IsBetween(CardHolderName.Length, 3, 100, nameof(CardHolderName), $"{nameof(CardHolderName)} must be between 3 and 100 characters")
                .IsCreditCard(CardNumber, nameof(CardNumber), $"{nameof(CardNumber)} is invalid")
            );
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}