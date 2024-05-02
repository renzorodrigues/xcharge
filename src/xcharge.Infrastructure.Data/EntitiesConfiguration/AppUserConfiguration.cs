using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xcharge.Domain.Entities;

namespace xcharge.Infrastructure.Data.EntitiesConfiguration;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(au => au.FullName).IsRequired().HasMaxLength(200).IsUnicode(false);

        builder.Property(au => au.Birthdate);

        builder.Property(au => au.PlaceOfBirth).HasMaxLength(50).IsUnicode(false);

        builder.Property(au => au.Nationality).HasMaxLength(30).IsUnicode(false);

        builder.ComplexProperty(au => au.Address).IsRequired();

        builder.ComplexProperty(au => au.Telephone).IsRequired();

        builder.ComplexProperty(au => au.Email).IsRequired();

        builder.ComplexProperty(au => au.Identification).IsRequired();
    }
}
