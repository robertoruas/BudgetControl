using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using System.Runtime.CompilerServices;

namespace BudgetControl.Core.Application.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly IExpenseService _expenseService;
        private readonly ICategoryService _categoryService;
        private readonly IIncomeService _incomeService;

        public SummaryService(IIncomeService incomeService, IExpenseService expenseService, ICategoryService categoryService)
        {
            _incomeService = incomeService ?? throw new ArgumentNullException(nameof(incomeService));
            _expenseService = expenseService ?? throw new ArgumentNullException(nameof(expenseService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public async Task<SummaryDTO> GetSummaryByMonthAndYear(int month, int year)
        {
            if (month < 1 || month > 12) throw new ArgumentOutOfRangeException(nameof(month), "Month needs be between 1 and 12.");

            var incomes = await _incomeService.GetByMonthAndYear(month, year);

            var expenses = await _expenseService.GetByMonthAndYear(month, year);

            decimal totalIncome = incomes.Sum(i => i.Value);
            decimal totalExpenses = expenses.Sum(e => e.Value);

            Dictionary<string, decimal> expenseDetails = new();

            var expensesPerCategory = expenses.GroupBy(e => e.CategoryId);

            foreach (var item in expensesPerCategory)
            {
                var category = await _categoryService.GetById(item.Key);
                decimal total = item.Sum(c => c.Value);

                expenseDetails.Add(category.Name, total);
            }

            SummaryDTO summary = new()
            {
                TotalIncome = totalIncome,
                TotalExpense = totalExpenses,
                Balance = totalIncome - totalExpenses,
                ExpenseDetails = expenseDetails
            };

            return summary;
        }

    }
}
