using System.Net;
using MediatR;
using xcharge.Application.CQS.Queries.Block;
using xcharge.Application.DTOs.Block.Responses;
using xcharge.Application.Interfaces.Mappers.Responses;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Shared.Helpers;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.BlockHandlers;

public class BlockGetByIdHandler(
    IBlockRepository repository,
    IBlockGetByIdMapper blockGetByIdMapper
) : IRequestHandler<BlockGetByIdQuery, Result<BlockGetByIdDto>>
{
    private readonly IBlockRepository _repository = repository;
    private readonly IBlockGetByIdMapper _blockGetByIdMapper = blockGetByIdMapper;

    public async Task<Result<BlockGetByIdDto>> Handle(
        BlockGetByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var entity = await this._repository.GetById(request.Id);

        if (entity is null)
        {
            return Result<BlockGetByIdDto>.RequestFailed(
                Response.ObjectNotFound,
                HttpStatusCode.NotFound
            );
        }

        var response = this._blockGetByIdMapper.Map(entity);

        return Result<BlockGetByIdDto>.RequestOk(response);
    }
}
