using BudgetControl.Core.Application.DTOs;

namespace BudgetControl.Core.Application.Interfaces
{
    public interface IExpenseService : IService<ExpenseDTO>
    {
        Task<IEnumerable<ExpenseDTO>> GetByMonthAndYear(int month, int year);

        Task<IEnumerable<ExpenseDTO>> GetByDescription(string description);
    }
}
