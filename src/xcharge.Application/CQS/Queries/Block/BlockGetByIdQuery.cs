using xcharge.Application.DTOs.Block.Responses;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Queries.Block;

public class BlockGetByIdQuery(Guid id) : Query<BlockGetByIdDto>
{
    public Guid Id { get; set; } = id;
}
