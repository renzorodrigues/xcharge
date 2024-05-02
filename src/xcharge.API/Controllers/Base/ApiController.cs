using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using xcharge.Shared.Handlers.Interfaces;
using xcharge.Shared.Helpers;

namespace xcharge.API.Controllers.Base;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ApiController(ILogger<ApiController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<ApiController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    // QUERIES
    protected async Task<IActionResult> ExecuteQueryAsync<TRequest, TResult>(
        TRequest query,
        CancellationToken cancellationToken
    )
        where TRequest : class, IQuery<TResult>
    {
        return await ExecuteAsync<TRequest, TResult>(query, cancellationToken);
    }

    protected async Task<IActionResult> ExecuteQueryAsync<TRequest>()
        where TRequest : class, IRequest, new()
    {
        return await ExecuteAsync(new TRequest());
    }

    // COMMANDS
    protected async Task<IActionResult> ExecuteCommandAsync<TRequest, TResult>(
        TRequest command,
        CancellationToken cancellationToken
    )
        where TRequest : class, ICommand<TResult>
    {
        return await ExecuteAsync<TRequest, TResult>(command, cancellationToken);
    }

    private async Task<IActionResult> ExecuteAsync<TRequest, TResult>(
        TRequest request,
        CancellationToken cancellationToken
    )
        where TRequest : class, IRequest<Result<TResult>>
    {
        IActionResult actionResult;

        var result = await this._mediator.Send(request, cancellationToken);

        if (result.IsSuccess)
        {
            actionResult = result.StatusCode switch
            {
                HttpStatusCode.Created => Created($"{Request.Path.Value}{result.Data}", result),
                HttpStatusCode.NoContent => NoContent(),
                _ => Ok(result)
            };
        }
        else
        {
            actionResult = result.StatusCode switch
            {
                HttpStatusCode.NotFound => NotFound(result),
                HttpStatusCode.Unauthorized => Unauthorized(result),
                _ => BadRequest(result)
            };
        }

        return actionResult;
    }

    private async Task<IActionResult> ExecuteAsync<TRequest>(TRequest request)
        where TRequest : class, IRequest
    {
        await this._mediator.Send(request);

        return NoContent();
    }
}
