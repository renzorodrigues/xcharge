using xcharge.Application.Interfaces.Repositories;
using xcharge.Domain.Entities;
using xcharge.Infrastructure.Data.DataContext;
using xcharge.Infrastructure.Data.Repositories.Functions;

namespace xcharge.Infrastructure.Data.Repositories;

public class BlockRepository(ApplicationDbContext dbContext) : IBlockRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Block> GetById(Guid id)
    {
        var result = await BlockCompileAsync.SingleAsync(this._dbContext, id);
        return result!;
    }
}
