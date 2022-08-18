using BudgetControl.Core.Domain.Entities;

namespace BudgetControl.Core.Domain.Interfaces
{
    public interface IIncomeRepository : IRepository<Income>
    {
        Task<IEnumerable<Income>> GetByMonthAndYear(int month, int year);

        Task<IEnumerable<Income>> GetByDescription(string description);
    }
}
