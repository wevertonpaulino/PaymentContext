using System;
using Flunt.Notifications;
using PaymentContext.Common.Commands;
using PaymentContext.Common.Handlers;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
        Notifiable<Notification>,
        IHandler<CreatePixPaymentSubscriptionCommand>,
        IHandler<CreateCreditCardSubscriptionCommand>
    {
        public ICommandResult Handle(CreatePixPaymentSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Unable to subscribe");
            }

            // Check repositories

            // Value Objects
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.District, command.ZipCode, command.City, command.State, command.Country);

            // Entities
            var student = new Student(name, document, email, address);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PixPayment(
                                    command.PaidDate,
                                    command.Total,
                                    command.TotalPaid,
                                    command.Payer,
                                    new Document(command.PayerDocument, command.PayerDocumentType),
                                    new Email(command.PayerEmail),
                                    address,
                                    command.PixPaymentKey,
                                    command.PixPaymentKeyType);

            // Relationships
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Group validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Check notifications
            if (!IsValid)
                return new CommandResult(false, "Unable to subscribe");

            // Save to repositories

            // Send email notifications

            // Return result
            return new CommandResult(true, "Successful subscription");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Unable to subscribe");
            }

            // Check repositories

            // Value Objects
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.District, command.ZipCode, command.City, command.State, command.Country);

            // Entities
            var student = new Student(name, document, email, address);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(
                                    command.PaidDate,
                                    command.Total,
                                    command.TotalPaid,
                                    command.Payer,
                                    new Document(command.PayerDocument, command.PayerDocumentType),
                                    new Email(command.PayerEmail),
                                    address,
                                    command.CardHolderName,
                                    command.CardNumber,
                                    command.LastTransactionNumber);

            // Relationships
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Group validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Check notifications
            if (!IsValid)
                return new CommandResult(false, "Unable to subscribe");

            // Save to repositories

            // Send email notifications

            // Return result
            return new CommandResult(true, "Successful subscription");
        }
    }
}