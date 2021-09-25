using Flunt.Validations;
using PaymentContext.Common.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<Email>()
                .Requires()
                .IsEmail(Address, nameof(Address), $"{nameof(Address)} is invalid")
            );
        }

        public string Address { get; private set; }
    }
}