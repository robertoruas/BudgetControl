using BudgetControl.Core.Domain.Entities;
using BudgetControl.Core.Domain.Interfaces;
using BudgetControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetByDescription(string description)
        {
            return await Entity.Where(c => c.Description.Contains(description)).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            return await Entity.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetByType(CategoryType type)
        {
            return await Entity.Where(c => c.Type == type).ToListAsync();
        }
    }
}
