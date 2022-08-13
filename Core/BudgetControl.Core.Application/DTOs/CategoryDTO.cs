using BudgetControl.Core.Domain.Entities;

namespace BudgetControl.Core.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public CategoryType Type { get; private set; }
    }
}
