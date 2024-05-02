using MediatR;
using Microsoft.AspNetCore.Mvc;
using xcharge.API.Controllers.Base;
using xcharge.Application.CQS.Commands.UserCommand;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;

namespace xcharge.API.Controllers.v1;

public class UserController(ILogger<ApiController> logger, IMediator mediator)
    : ApiController(logger, mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromBody] UserCreateCommand command,
        CancellationToken cancellationToken
    ) => await ExecuteCommandAsync<UserCreateCommand, Guid>(command, cancellationToken);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) =>
        await ExecuteQueryAsync<UserGetByIdQuery, UserGetByIdDto>(new(id), cancellationToken);

    [HttpGet("search/{name}")]
    public async Task<IActionResult> Search(string name, CancellationToken cancellationToken) =>
        await ExecuteQueryAsync<UserSearchQuery, IEnumerable<AppUserSearchDto>>(
            new(name),
            cancellationToken
        );
}
