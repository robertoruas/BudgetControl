using BudgetControl.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Core.Domain.Interfaces
{
    public interface IOutgoingRepository : IRepository<Outgoing>
    {
        Task<IEnumerable<Outgoing>> GetByMonthAndYear(Months month, int year);
    }
}
