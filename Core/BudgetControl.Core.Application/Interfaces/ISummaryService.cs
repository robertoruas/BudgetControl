using BudgetControl.Core.Application.DTOs;

namespace BudgetControl.Core.Application.Interfaces
{
    public interface ISummaryService
    {
        Task<SummaryDTO> GetSummaryByMonthAndYear(int month, int year);
    }
}
