using BudgetControl.Core.Application.DTOs;

namespace BudgetControl.Core.Application.Interfaces
{
    public interface IUserService : IService<UserDTO>
    {
        Task<UserDTO> GetUserByUsername(string username);
    }
}
