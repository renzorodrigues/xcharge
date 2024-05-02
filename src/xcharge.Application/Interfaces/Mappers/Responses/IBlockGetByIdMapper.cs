using xcharge.Application.DTOs.Block.Responses;
using xcharge.Domain.Entities;

namespace xcharge.Application.Interfaces.Mappers.Responses;

public interface IBlockGetByIdMapper
{
    BlockGetByIdDto Map(Block entity);
}
