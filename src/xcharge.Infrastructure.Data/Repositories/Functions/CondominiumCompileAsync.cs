using Microsoft.EntityFrameworkCore;
using xcharge.Domain.Entities;
using xcharge.Infrastructure.Data.DataContext;

namespace xcharge.Infrastructure.Data.Repositories.Functions;

public static class CondominiumCompileAsync
{
    public static readonly Func<ApplicationDbContext, Guid, Task<Condominium?>> SingleAsync =
        EF.CompileAsyncQuery(
            (ApplicationDbContext context, Guid id) =>
                context.Condominiums.FirstOrDefault(x => x.Id == id)
        );
}
