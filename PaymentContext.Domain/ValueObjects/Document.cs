using Flunt.Extensions.Br.Validations;
using Flunt.Validations;
using PaymentContext.Common.ValueObjects;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract<Document>()
                .Requires()
                .IsCpfOrCnpj(Number, nameof(Number), $"{nameof(Number)} is invalid")
            );
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}