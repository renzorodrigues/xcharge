using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xcharge.Domain.Entities;

namespace xcharge.Infrastructure.Data.EntitiesConfiguration;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(u => u.Code).IsRequired().HasMaxLength(10).IsUnicode(false);

        builder.Property(u => u.Size);

        builder.Property(u => u.IsRented).IsRequired().HasDefaultValue(false);

        builder.Property(u => u.IsForRent).IsRequired().HasDefaultValue(false);

        builder.Property(u => u.IsDefaulter).IsRequired().HasDefaultValue(false);

        builder.HasOne(u => u.Owner);

        builder.HasOne(u => u.Tenant);
    }
}
