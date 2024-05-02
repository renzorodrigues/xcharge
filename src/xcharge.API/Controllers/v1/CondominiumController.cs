using MediatR;
using Microsoft.AspNetCore.Mvc;
using xcharge.API.Controllers.Base;
using xcharge.Application.CQS.Commands.CondominiumCommand;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;

namespace xcharge.API.Controllers.v1;

public class CondominiumController(ILogger<ApiController> logger, IMediator mediator)
    : ApiController(logger, mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) =>
        await ExecuteQueryAsync<CondominiumGetByIdQuery, CondominiumGetByIdDto>(
            new(id),
            cancellationToken
        );

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken) =>
        await ExecuteQueryAsync<CondominiumGetAllQuery, IEnumerable<CondominiumGetAllDto>>(
            new(),
            cancellationToken
        );

    [HttpPost]
    public async Task<IActionResult> CreateCondominium(
        [FromBody] CondominiumCreateCommand command,
        CancellationToken cancellationToken
    ) => await ExecuteCommandAsync<CondominiumCreateCommand, Guid>(command, cancellationToken);

    [HttpPut("add-manager")]
    public async Task<IActionResult> AddManager(
        [FromBody] AddManagerCommand command,
        CancellationToken cancellationToken
    ) => await ExecuteCommandAsync<AddManagerCommand, Guid>(command, cancellationToken);

    [HttpGet("receita-federal/{cnpj}")]
    public async Task<IActionResult> GetReceitaFederalData(
        string cnpj,
        CancellationToken cancellationToken
    ) =>
        await ExecuteQueryAsync<
            CondominiumGetReceitaFederalDataQuery,
            CondominiumReceitaFederalDto
        >(new(cnpj), cancellationToken);
}
