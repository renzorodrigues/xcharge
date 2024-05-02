using Microsoft.EntityFrameworkCore;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Domain.Entities;
using xcharge.Infrastructure.Data.DataContext;

namespace xcharge.Infrastructure.Data.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> Create(AppUser entity)
    {
        this._dbContext.Add(entity);
        await this._dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<AppUserSearchDto>> GetAllPaged(string name)
    {
        var result = await this
            ._dbContext.AppUsers.Where(x => x.FullName!.ToLower()!.Contains(name.ToLower()))
            .Select(x => new AppUserSearchDto
            {
                FullName = x.FullName,
                Id = x.Id,
                CPF = x.Identification!.Cpf
            })
            .ToListAsync();

        return result;
    }

    public async Task<AppUser> GetById(Guid id)
    {
        var result = await this._dbContext.AppUsers.FirstOrDefaultAsync(u => u.Id == id);

        return result!;
    }
}
