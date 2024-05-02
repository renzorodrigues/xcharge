using xcharge.Domain.Entities;

namespace xcharge.Application.Interfaces.Repositories;

public interface ICondominiumRepository
{
    Task<Condominium> GetById(Guid id);
    Task<IEnumerable<Condominium>> GetAll();
    Task<Guid> Create(Condominium entity);
    Task<Guid> Update(Condominium entity);
}
