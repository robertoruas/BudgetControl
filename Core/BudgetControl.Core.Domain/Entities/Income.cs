namespace BudgetControl.Core.Domain.Entities
{
    public class Income : Entity
    {
        public string Description { get; private set; }

        public decimal Value { get; private set; }

        public DateTime Date { get; private set; }


    }
}
