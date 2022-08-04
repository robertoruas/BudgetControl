using System.ComponentModel.DataAnnotations;

namespace BudgetControl.Core.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [MinLength(5), MaxLength(20), Required(ErrorMessage = "Username is Required.")]
        public string UserName { get; set; }

        [MaxLength(200), Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}")]
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }
    }
}
