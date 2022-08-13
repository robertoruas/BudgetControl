using BudgetControl.Core.Domain.Entities;
using BudgetControl.Core.Domain.Interfaces;
using BudgetControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Persistence.Repositories
{
    public class IncomeRepository : Repository<Income>, IIncomeRepository
    {
        public IncomeRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<Income>> GetByMonthAndYear(int month, int year)
        {
            return await Entity.Where(x => x.Date.Month == month && x.Date.Year == year).ToListAsync();
        }
    }
}
