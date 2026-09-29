namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObjects
    {
        public email(string address)
        {
            Address = address;
        }
        public string Address { get; private set; }
    }
}