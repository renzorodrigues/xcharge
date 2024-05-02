using Microsoft.EntityFrameworkCore;
using xcharge.Domain.Entities;
using xcharge.Infrastructure.Data.DataContext;

namespace xcharge.Infrastructure.Data.Repositories.Functions;

public static class BlockCompileAsync
{
    public static readonly Func<ApplicationDbContext, Guid, Task<Block?>> SingleAsync =
        EF.CompileAsyncQuery(
            (ApplicationDbContext context, Guid id) =>
                context.Blocks.Include(x => x.Units).FirstOrDefault(x => x.Id == id)
        );
}
