using BudgetControl.Core.Application.Interfaces;
using BudgetControl.Core.Application.Services;
using BudgetControl.Core.Domain.Interfaces;
using BudgetControl.Infrastructure.Persistence.Context;
using BudgetControl.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetControl.Infrastructure.Shared.ConfigurationServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationContext).FullName)));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IExpenseService, ExpenseService>();

            return services;
        }
    }
}
