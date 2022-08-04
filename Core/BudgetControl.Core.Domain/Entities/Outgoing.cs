namespace BudgetControl.Core.Domain.Entities
{
    public class Outgoing : Entity
    {
        public string Description { get; private set; }

        public decimal Value { get; private set; }

        public DateTime Date { get; private set; }
    }
}
