using PaymentContext.Common.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string district, string city, string zipCode, string state, string country)
        {
            Street = street;
            Number = number;
            District = district;
            City = city;
            ZipCode = zipCode;
            State = state;
            Country = country;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
    }
}