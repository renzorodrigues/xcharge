using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xcharge.Domain.Entities.Base;

namespace xcharge.Infrastructure.Data.EntitiesConfiguration;

public class AppUserCondominiumConfiguration : IEntityTypeConfiguration<AppUserCondominium>
{
    public void Configure(EntityTypeBuilder<AppUserCondominium> builder)
    {
        builder.HasKey(k => new { k.CondominiumId, k.AppUserId });

        builder
            .HasOne(uc => uc.Condominium)
            .WithMany(uc => uc.AppUserCondominiums)
            .HasForeignKey(uc => uc.CondominiumId);

        builder
            .HasOne(uc => uc.AppUser)
            .WithMany(uc => uc.AppUserCondominiums)
            .HasForeignKey(uc => uc.AppUserId);

        builder.Property(uc => uc.UserType).HasConversion<string>().IsRequired();
    }
}
