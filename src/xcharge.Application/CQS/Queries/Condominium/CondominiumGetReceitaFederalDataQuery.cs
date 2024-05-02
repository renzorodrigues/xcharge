using xcharge.Application.DTOs.Condominium;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Queries.Condominium;

public class CondominiumGetReceitaFederalDataQuery(string cnpj)
    : Query<CondominiumReceitaFederalDto>
{
    public string[] Parameters { get; set; } = [cnpj];
}
