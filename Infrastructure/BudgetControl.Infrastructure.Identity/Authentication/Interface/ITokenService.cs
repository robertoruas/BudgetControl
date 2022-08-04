using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Domain.Entities;

namespace BudgetControl.Infrastructure.Identity.Authentication.Interface
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
    }
}
