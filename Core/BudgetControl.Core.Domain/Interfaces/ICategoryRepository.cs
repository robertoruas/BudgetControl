using BudgetControl.Core.Domain.Entities;

namespace BudgetControl.Core.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetByName(string name);

        Task<IEnumerable<Category>> GetByDescription(string description);

        Task<IEnumerable<Category>> GetByType(CategoryType type);
    }
}
