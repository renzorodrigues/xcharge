using MediatR;
using Microsoft.AspNetCore.Mvc;
using xcharge.API.Controllers.Base;
using xcharge.Application.CQS.Queries.Block;
using xcharge.Application.DTOs.Block.Responses;

namespace xcharge.API.Controllers.v1;

public class BlockController(ILogger<ApiController> logger, IMediator mediator)
    : ApiController(logger, mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) =>
        await ExecuteQueryAsync<BlockGetByIdQuery, BlockGetByIdDto>(new(id), cancellationToken);
}
