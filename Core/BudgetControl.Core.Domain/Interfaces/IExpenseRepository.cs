using BudgetControl.Core.Domain.Entities;

namespace BudgetControl.Core.Domain.Interfaces
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<IEnumerable<Expense>> GetByMonthAndYear(int month, int year);

        Task<IEnumerable<Income>> GetByDescription(string description);
    }
}
