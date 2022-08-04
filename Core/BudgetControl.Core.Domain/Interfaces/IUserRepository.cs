using BudgetControl.Core.Domain.Entities;

namespace BudgetControl.Core.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByName(string username);

        Task<User> GetByUsernameAndPassword(string username, string password);
    }
}
