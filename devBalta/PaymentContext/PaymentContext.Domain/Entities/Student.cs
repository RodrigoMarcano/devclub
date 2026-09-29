using System.Collections.Generic;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name Name, Document document, Email email, Address address)
        {
            Name = Name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return_subscriptions.ToArray(); } }
        public void AddSubsccription(Subscription subscription)
        {
            // Se já tiver uma assinatura ativa, cancela

            // Cancela todas as outras assinatura, e coloca esta
            // como principal
            foreach (var sub in Subscriptions)
                sub.Inactive();

            _subscriptions.Add(subscription);
        }
    }
}