using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xcharge.Domain.Entities;

namespace xcharge.Infrastructure.Data.EntitiesConfiguration;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(t => t.IsActive).HasDefaultValue(false);

        builder.Property(t => t.Name).IsRequired().HasMaxLength(200).IsUnicode(false);

        builder.ComplexProperty(t => t.Address).IsRequired();

        builder.ComplexProperty(t => t.Telephone).IsRequired();

        builder.ComplexProperty(t => t.Email).IsRequired();

        builder.ComplexProperty(t => t.Identification).IsRequired();

        builder
            .HasMany(t => t.Condominiums)
            .WithOne(c => c.Tenant)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
