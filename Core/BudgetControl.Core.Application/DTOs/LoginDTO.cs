using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Core.Application.DTOs
{
    public class LoginDTO
    {
        [MinLength(5), MaxLength(20), Required(ErrorMessage = $"{nameof(UserName)} is Required.")]
        public string UserName { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}")]
        [Required(ErrorMessage = $"{nameof(Password)} is Required.")]
        public string Password { get; set; }
    }
}
