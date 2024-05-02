using xcharge.Application.CQS.Commands.BankSlipCommand;
using xcharge.Application.DTOs.BankSlip.Requests;

namespace xcharge.Application.Interfaces.Mappers;

public interface IBankSlipIssueMapper
{
    BankSlipIssueRequest Map(BankSlipIssueCommand command);
}
