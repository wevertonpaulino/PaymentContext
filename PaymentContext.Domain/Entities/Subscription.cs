using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Common.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private readonly IList<Payment> _payments;

        public Subscription(DateTime? expireDate = null)
        {
            ExpireDate = expireDate;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Active = false;

            AddNotifications(new Contract<Subscription>()
                .Requires()
                .IsGreaterOrEqualsThan(ExpireDate ?? DateTime.Now, CreateDate, nameof(ExpireDate),
                    $"{nameof(ExpireDate)} must be greater than or equal to {nameof(CreateDate)}")
            );

            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyList<Payment> Payments
        {
            get { return _payments.ToList(); }
        }

        public void AddPayment(Payment payment)
        {
            if (_payments.Any())
                AddNotification(nameof(Payments), "Subscription already has payment");

            AddNotifications(payment);

            if (IsValid)
            {
                _payments.Add(payment);
                Active = true;
            }
        }

        public void Activate(bool active)
        {
            Active = active;
            LastUpdateDate = DateTime.Now;
        }
    }
}