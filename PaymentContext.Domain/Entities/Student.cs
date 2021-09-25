using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Common.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private readonly IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;

            AddNotifications(Name, Document, Email, Address);

            _subscriptions = new List<Subscription>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyList<Subscription> Subscriptions
        {
            get { return _subscriptions.ToList(); }
        }

        public void AddSubscription(Subscription subscription)
        {
            if (_subscriptions.Any(x => x.Active))
                AddNotification(nameof(Subscriptions), "Student already has active subscription");

            AddNotifications(subscription);

            if (IsValid)
                _subscriptions.Add(subscription);
        }
    }
}