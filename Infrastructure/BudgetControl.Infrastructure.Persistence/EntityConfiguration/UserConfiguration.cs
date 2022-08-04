using BudgetControl.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControl.Infrastructure.Persistence.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Name).HasMaxLength(200).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(20).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(256).IsRequired();

            builder.HasData(new User(1, "System Administrator", "PassCrypto", "administrator"));
        }
    }
}
