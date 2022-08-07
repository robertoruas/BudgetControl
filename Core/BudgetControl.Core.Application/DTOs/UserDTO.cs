using BudgetControl.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BudgetControl.Core.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [MinLength(5), MaxLength(20), Required(ErrorMessage = $"{nameof(UserName)} is Required.")]
        public string UserName { get; set; }

        [MaxLength(200), Required(ErrorMessage = $"{nameof(Name)} is Required.")]
        public string Name { get; set; }

        [MaxLength(200), Required(ErrorMessage = $"{nameof(Email)} is Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = $"{nameof(Password)} is Required.")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Password { get; set; }

        public UserStatus Status { get; set; }
    }
}
