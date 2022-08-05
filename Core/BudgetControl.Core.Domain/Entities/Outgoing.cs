namespace BudgetControl.Core.Domain.Entities
{
    public class Outgoing : Entity
    {
        public Outgoing(string description, decimal value, DateTime date)
        {
            if (value <= 0) throw new ArgumentException("The Income value must be greater than 0.", nameof(value));
            if (date == DateTime.MinValue || date == DateTime.MaxValue) throw new ArgumentException("Enter a valid date.", nameof(value));

            Description = description ?? throw new ArgumentNullException(nameof(description));
            Value = value;
            Date = date;
        }

        public Outgoing(int id, string description, decimal value, DateTime date)
        {
            if (value <= 0) throw new ArgumentException("The Income value must be greater than 0.", nameof(value));
            if (date == DateTime.MinValue || date == DateTime.MaxValue) throw new ArgumentException("Enter a valid date.", nameof(value));

            Id = id;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Value = value;
            Date = date;
        }

        public string Description { get; private set; }

        public decimal Value { get; private set; }

        public DateTime Date { get; private set; }
    }
}
