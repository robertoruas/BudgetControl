using BudgetControl.Core.Domain.Entities;
using BudgetControl.Core.Domain.Interfaces;
using BudgetControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Infrastructure.Persistence.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<Expense>> GetByMonthAndYear(int month, int year)
        {
            return await Entity.Where(x => x.Date.Month == month && x.Date.Year == year).ToListAsync();
        }
    }
}
