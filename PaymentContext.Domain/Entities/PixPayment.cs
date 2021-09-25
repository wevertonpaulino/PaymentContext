using System;
using Flunt.Extensions.Br.Validations;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PixPayment : Payment
    {
        public PixPayment(DateTime paidDate, decimal total, decimal totalPaid, string payer, Document document, Email email, Address address, string key, EPixKeyType type)
            : base(paidDate, total, totalPaid, payer, document, email, address)
        {
            Key = key;
            Type = type;

            AddNotifications(GetContract());
        }

        public string Key { get; private set; }
        public EPixKeyType Type { get; set; }

        private Contract<PixPayment> GetContract()
        {
            var contract = new Contract<PixPayment>().Requires();

            if (Type == EPixKeyType.EMAIL)
                return contract.IsEmail(Key, nameof(Key), $"{nameof(Key)} is invalid");
            
            if (Type == EPixKeyType.PHONE_NUMBER)
                return contract.IsPhoneNumber(Key, nameof(Key), $"{nameof(Key)} is invalid");
            
            if (Type == EPixKeyType.CPF_CNPJ)
                return contract.IsCpfOrCnpj(Key, nameof(Key), $"{nameof(Key)} is invalid");
            
            return contract;
        }
    }
}