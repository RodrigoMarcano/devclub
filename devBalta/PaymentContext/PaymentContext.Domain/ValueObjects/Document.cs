namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObjects
    {
        public Document(string number)
        {
            Number = number;

        }

        public string Number { get; private set; }
        public int MyProperty { get; private set; }

    }
}