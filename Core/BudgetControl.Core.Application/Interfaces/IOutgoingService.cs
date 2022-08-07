using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Domain.Entities;

namespace BudgetControl.Core.Application.Interfaces
{
    public interface IOutgoingService : IService<OutgoingDTO>
    {
        Task<IEnumerable<OutgoingDTO>> GetByMonthAndYear(int month, int year);
    }
}
