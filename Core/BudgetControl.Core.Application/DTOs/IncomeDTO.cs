using System.ComponentModel.DataAnnotations;

namespace BudgetControl.Core.Application.DTOs
{
    public class IncomeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = $"{nameof(Description)} is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = $"{nameof(Description)} is required."), DataType(DataType.Currency)]
        public decimal Value { get; set; }

        [Required(ErrorMessage = $"{nameof(Description)} is required."), DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
