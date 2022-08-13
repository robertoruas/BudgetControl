namespace BudgetControl.Core.Domain.Entities
{
    public class Category : Entity
    {
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
