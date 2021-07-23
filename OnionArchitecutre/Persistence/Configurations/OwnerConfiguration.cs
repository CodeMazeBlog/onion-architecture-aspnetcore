using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable(nameof(Owner));

            builder.HasKey(owner => owner.Id);

            builder.Property(account => account.Id).ValueGeneratedOnAdd();

            builder.Property(owner => owner.Name).HasMaxLength(60);

            builder.Property(owner => owner.DateOfBirth).IsRequired();

            builder.Property(owner => owner.Address).HasMaxLength(100);

            builder.HasMany(owner => owner.Accounts)
                .WithOne()
                .HasForeignKey(account => account.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
