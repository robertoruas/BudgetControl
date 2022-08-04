using BudgetControl.Core.Domain.Entities;
using System.Linq.Expressions;

namespace BudgetControl.Core.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> Get();

        Task<T> GetById(int id);

        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate = null);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);

    }
}
