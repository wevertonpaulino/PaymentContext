using Flunt.Extensions.Br.Validations;
using Flunt.Validations;
using PaymentContext.Common.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string district, string zipCode, string city, string state, string country)
        {
            Street = street;
            Number = number;
            District = district;
            ZipCode = zipCode;
            City = city;
            State = state;
            Country = country;

            AddNotifications(new Contract<Address>()
                .Requires()
                .IsNotNullOrEmpty(Street, nameof(Street), $"{nameof(Street)} is null or empty")
                .IsNotNullOrEmpty(Number, nameof(Number), $"{nameof(Number)} is null or empty")
                .IsNotNullOrEmpty(District, nameof(District), $"{nameof(District)} is null or empty")
                .IsZipCode(ZipCode, nameof(ZipCode), $"{nameof(ZipCode)} is invalid")
                .IsNotNullOrEmpty(City, nameof(City), $"{nameof(City)} is null or empty")
                .IsState(State, nameof(State), $"{nameof(State)} is invalid")
                .IsCountry(Country, nameof(Country), $"{nameof(Country)} is invalid")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
    }
}