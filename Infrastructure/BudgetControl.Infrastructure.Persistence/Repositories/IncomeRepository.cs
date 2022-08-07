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
    public class IncomeRepository : Repository<Income>, IIncomeRepository
    {
        public IncomeRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<Income>> GetByMonthAndYear(Months month, int year)
        {
            return await Entity.Where(x => x.Month == month && x.Year == year).ToListAsync();
        }
    }
}
