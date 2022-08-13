using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Domain.Entities;

namespace BudgetControl.Core.Application.Interfaces
{
    public interface IExpenseService : IService<ExpenseDTO>
    {
        Task<IEnumerable<ExpenseDTO>> GetByMonthAndYear(int month, int year);
    }
}
