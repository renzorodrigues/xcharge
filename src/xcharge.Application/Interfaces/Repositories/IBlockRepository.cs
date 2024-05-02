using xcharge.Domain.Entities;

namespace xcharge.Application.Interfaces.Repositories;

public interface IBlockRepository
{
    Task<Block> GetById(Guid id);
}
