using Flunt.Validations;
using PaymentContext.Common.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
                .Requires()
                .IsNotNullOrEmpty(FirstName, nameof(FirstName), $"{nameof(FirstName)} is invalid")
                .IsNotNullOrEmpty(LastName, nameof(LastName), $"{nameof(LastName)} is invalid")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}