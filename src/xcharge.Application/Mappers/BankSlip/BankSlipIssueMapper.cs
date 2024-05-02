using xcharge.Application.CQS.Commands.BankSlipCommand;
using xcharge.Application.DTOs.BankSlip.Requests;
using xcharge.Application.Interfaces.Mappers;

namespace xcharge.Application.Mappers.BankSlip;

public class BankSlipIssueMapper : IBankSlipIssueMapper
{
    public BankSlipIssueRequest Map(BankSlipIssueCommand command)
    {
        var request = new BankSlipIssueRequest()
        {
            ExpirationDate = command.ExpirationDate.ToString("MM/dd/yyyy"),
            Amount = command.Amount,
            Fine = command.FineRate,
            Interests = command.InterestRate,
            PublicArea = "Rua do Ze",
            Number = "1000",
            District = "Fubalina",
            City = "Uberlandia",
            State = "Minas Gerais",
            ZipCode = "38400-000",
            Name = "Ze das Couve",
            CPF = "010111222-55",
            Email = "zecouve@gmail.com",
            Telephone = "34 32223333",
            DocumentType = "DS",
            RequestNumber = "18185959",
            Instructions = "Aqui vai instrucoes",
            AdditionalInstructions = "Aqui vai instrucoes adicionais",
            Text = "Aqui tem um texto",
            Group = "Grupo1",
        };

        return request;
    }
}
