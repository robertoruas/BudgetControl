using BudgetControl.Core.Application.Mappings;

namespace BudgetControl.Api.AutoMapConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        }
    }
}
