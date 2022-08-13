using BudgetControl.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
