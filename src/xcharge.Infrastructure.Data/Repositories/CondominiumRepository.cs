using Microsoft.EntityFrameworkCore;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Domain.Entities;
using xcharge.Domain.Entities.Base;
using xcharge.Infrastructure.Data.DataContext;
using xcharge.Infrastructure.Data.Repositories.Functions;

namespace xcharge.Infrastructure.Data.Repositories;

public class CondominiumRepository(ApplicationDbContext dbContext) : ICondominiumRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> Create(Condominium entity)
    {
        this._dbContext.Add(entity);
        await this._dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Condominium>> GetAll()
    {
        var result = await this
            ._dbContext.Condominiums.AsNoTracking()
            .Include(x => x.AppUserCondominiums!)
            .ThenInclude(x => x.AppUser)
            .OrderBy(x => x.Name)
            .ToListAsync();
        // .Skip((pageNumber - 1) * pageSize)
        // .Take(pageSize)
        // .ToListAsync();

        return result;
    }

    public async Task<Condominium> GetById(Guid id)
    {
        var result = await CondominiumCompileAsync.SingleAsync(this._dbContext, id);
        return result!;
    }

    public async Task<Guid> Update(Condominium entity)
    {
        await this._dbContext.SaveChangesAsync();
        return entity.Id;
    }
}
