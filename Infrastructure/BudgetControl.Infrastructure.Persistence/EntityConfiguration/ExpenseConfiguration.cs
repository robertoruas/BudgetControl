using BudgetControl.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControl.Infrastructure.Persistence.EntityConfiguration
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Value).HasPrecision(16, 2).IsRequired();
            builder.Property(x => x.Date).HasColumnType("date").IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(c => c.Expenses)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
