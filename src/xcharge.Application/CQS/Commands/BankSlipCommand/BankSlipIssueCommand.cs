using xcharge.Application.DTOs.BankSlip.Responses;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Commands.BankSlipCommand;

public record BankSlipIssueCommand : Command<BankSlipIssueDto>
{
    public Guid UnitId { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime DateOfIssue { get; set; }
    public double Amount { get; set; }
    public double Discount { get; set; }
    public double InterestRate { get; set; }
    public double FineRate { get; set; }
}
