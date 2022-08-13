using BudgetControl.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Core.Domain.Interfaces
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<IEnumerable<Expense>> GetByMonthAndYear(int month, int year);
    }
}
