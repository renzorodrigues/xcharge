using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using xcharge.Domain.Entities;
using xcharge.Domain.Entities.Base;

namespace xcharge.Infrastructure.Data.DataContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<AccountUser>(options)
{
    static ApplicationDbContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Condominium> Condominiums { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AccountUser> AccountUsers { get; set; }
    public DbSet<AppUserCondominium> AppUserCondominiums { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Block> Blocks { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
}
