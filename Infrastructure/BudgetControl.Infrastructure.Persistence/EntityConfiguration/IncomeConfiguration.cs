using BudgetControl.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControl.Infrastructure.Persistence.EntityConfiguration
{
    public class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Value).HasPrecision(16, 2).IsRequired();
            builder.Property(x => x.Date).HasColumnType("date").IsRequired();
        }
    }
}
