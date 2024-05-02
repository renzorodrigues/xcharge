using MediatR;
using Microsoft.AspNetCore.Mvc;
using xcharge.API.Controllers.Base;
using xcharge.Application.CQS.Commands.BankSlipCommand;
using xcharge.Application.DTOs.BankSlip.Responses;

namespace xcharge.API.Controllers.v1;

public class BankSlipController(ILogger<ApiController> logger, IMediator mediator)
    : ApiController(logger, mediator)
{
    [HttpPost]
    public async Task<IActionResult> BankSlipIssue(
        [FromBody] BankSlipIssueCommand command,
        CancellationToken cancellationToken
    ) =>
        await ExecuteCommandAsync<BankSlipIssueCommand, BankSlipIssueDto>(
            command,
            cancellationToken
        );
}
