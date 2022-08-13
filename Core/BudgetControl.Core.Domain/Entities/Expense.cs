namespace BudgetControl.Core.Domain.Entities
{
    public class Expense : Entity
    {
        public Expense(string description, decimal value, DateTime date, int categoryId)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Value = value;
            Date = date;
            CategoryId = categoryId;

            Validate();
        }

        public Expense(int id, string description, decimal value, DateTime date, int categoryId)
        {
            Id = id;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Value = value;
            Date = date;
            CategoryId = categoryId;

            Validate();
        }

        public string Description { get; private set; }

        public decimal Value { get; private set; }

        public DateTime Date { get; private set; }

        public int CategoryId { get; private set; }

        public Category Category { get; set; }

        public Months Month
        {
            get
            {
                return (Months)Date.Month;
            }
        }

        public int Year
        {
            get
            {
                return Date.Year;
            }
        }

        private void Validate()
        {
            if (Value <= 0) throw new ArgumentException("The Income value must be greater than 0.", nameof(Value));
            if (Date == DateTime.MinValue || Date == DateTime.MaxValue) throw new ArgumentException("Enter a valid date.", nameof(Date));
            if (CategoryId <= 0) throw new ArgumentException("Enter a valid category", nameof(CategoryId));
        }
    }
}
