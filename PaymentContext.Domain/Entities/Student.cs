using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private readonly IList<Subscription> _subscriptions;

        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyList<Subscription> Subscriptions
        {
            get { return _subscriptions.ToList(); }
        }

        public void AddSubscription(Subscription subscription)
        {
            foreach (var sub in _subscriptions)
                sub.Activate(false);

            _subscriptions.Add(subscription);
        }
    }
}