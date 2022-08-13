using BudgetControl.Core.Application.DTOs;

namespace BudgetControl.Core.Application.Interfaces
{
    public interface ICategoryService : IService<CategoryDTO>
    {
        Task<IEnumerable<CategoryDTO>> GetByDescription(string description);

        Task<IEnumerable<CategoryDTO>> GetByName(string name);

        Task<IEnumerable<CategoryDTO>> GetByType(int type);
    }
}
