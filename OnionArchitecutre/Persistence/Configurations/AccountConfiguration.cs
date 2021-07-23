using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));

            builder.HasKey(account => account.Id);

            builder.Property(account => account.Id).ValueGeneratedOnAdd();

            builder.Property(account => account.AccountType).HasMaxLength(50);

            builder.Property(account => account.DateCreated).IsRequired();
        }
    }
}
