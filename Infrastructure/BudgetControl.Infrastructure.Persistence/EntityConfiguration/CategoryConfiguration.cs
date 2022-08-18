using BudgetControl.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControl.Infrastructure.Persistence.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Type).HasColumnType("tinyint").IsRequired();

            builder.HasMany(x => x.Incomes)
                .WithOne(i => i.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Expenses)
                .WithOne(i => i.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Category(1, "Alimentação", "Despesas em geral com alimentação.", CategoryType.Outbound));
            builder.HasData(new Category(2, "Saúde", "Despesas em geral com saúde.", CategoryType.Outbound));
            builder.HasData(new Category(3, "Moraria", "Despesas em geral com moradia.", CategoryType.Outbound));
            builder.HasData(new Category(4, "Transporte", "Despesas em geral com transporte.", CategoryType.Outbound));
            builder.HasData(new Category(5, "Educação", "Despesas em geral com educação.", CategoryType.Outbound));
            builder.HasData(new Category(6, "Lazer", "Despesas em geral com lazer.", CategoryType.Outbound));
            builder.HasData(new Category(7, "Imprevistos", "Despesas em geral com imprevistos.", CategoryType.Outbound));
            builder.HasData(new Category(8, "Outras", "Outras despesas não previstas.", CategoryType.Outbound));
            builder.HasData(new Category(9, "Salário", "Salário recebido.", CategoryType.Inbound));
            builder.HasData(new Category(10, "Freelance", "Renda extra realizada e remunerada.", CategoryType.Inbound));

        }
    }
}
