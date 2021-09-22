using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private readonly IList<Payment> _payments;

        public Subscription(DateTime? expireDate)
        {
            ExpireDate = expireDate;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Active = true;
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
            _payments.Add(payment);
        }

        public void Activate(bool active)
        {
            Active = active;
            LastUpdateDate = DateTime.Now;
        }
    }
}