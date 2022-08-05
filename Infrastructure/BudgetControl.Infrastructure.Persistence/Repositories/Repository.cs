using BudgetControl.Core.Domain.Entities;
using BudgetControl.Core.Domain.Interfaces;
using BudgetControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Infrastructure.Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected ApplicationContext Context { get; }

        protected DbSet<T> Entity { get; }

        public Repository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Entity = Context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await Entity.ToListAsync();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await Get();

            return await Entity.Where(predicate).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
