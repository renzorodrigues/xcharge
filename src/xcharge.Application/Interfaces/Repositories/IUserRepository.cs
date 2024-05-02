using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Domain.Entities;

namespace xcharge.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<AppUser> GetById(Guid id);
    Task<Guid> Create(AppUser entity);
    Task<IEnumerable<AppUserSearchDto>> GetAllPaged(string name);
}
