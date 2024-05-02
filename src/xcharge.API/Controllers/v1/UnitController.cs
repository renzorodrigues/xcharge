using MediatR;
using xcharge.API.Controllers.Base;

namespace xcharge.API.Controllers.v1;

public class UnitController(ILogger<ApiController> logger, IMediator mediator)
    : ApiController(logger, mediator)
{
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) =>
    //     await ExecuteQueryAsync<BlockGetByIdQuery, BlockGetByIdResponse>(new(id), cancellationToken);
}
