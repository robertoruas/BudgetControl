using BudgetControl.Core.Domain.Entities;
using BudgetControl.Core.Domain.Interfaces;
using BudgetControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context) { }
        public async Task<User> GetByName(string username)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
