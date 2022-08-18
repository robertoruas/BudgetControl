namespace BudgetControl.Core.Domain.Entities
{
    public class Category : Entity
    {
        public Category(int id, string name, string description, CategoryType type)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Type = type;
        }

        public Category(string name, string description, CategoryType type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Type = type;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public CategoryType Type { get; private set; }

        public IEnumerable<Income> Incomes { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }
    }

    public enum CategoryType
    {
        Inbound = 0,
        Outbound = 1,
    }
}
