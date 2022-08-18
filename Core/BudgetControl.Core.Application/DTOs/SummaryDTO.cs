using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Core.Application.DTOs
{
    public class SummaryDTO
    {
        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal Balance { get; set; }

        public Dictionary<string, decimal> ExpenseDetails { get; set; }
    }
}
