using System;

using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Document document, string payer, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Document = document;
            Payer = payer;
            Address = address;
            Email = email;
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Document Document { get; private set; }
        public string Payer { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }

    }
    public class BoletoPayment : Payment
    {
        public string BarCod { get; set; }
        public string BoletoNumber { get; set; }

    }
    public class CreditCardPayment : Payment
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }

    }
    public class PayPalPayment : Payment
    {
        public string TransactionCode { get; set; }
    }
}