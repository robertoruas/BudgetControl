using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Core.Application.Interfaces
{
    public interface IIncomeService : IService<IncomeDTO>
    {
        Task<IEnumerable<IncomeDTO>> GetByMonthAndYear(int month, int year);
    }
}
