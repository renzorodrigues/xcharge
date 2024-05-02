using MediatR;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium;
using xcharge.Application.Extensions;
using xcharge.Application.Interfaces.Services;
using xcharge.Shared.Helpers;
using xcharge.Shared.Settings.HttpClientSettings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class CondominiumGetReceitaFederalDataHandler(
    IHttpClient<string[], CondominiumReceitaFederalDto> httpClient
) : IRequestHandler<CondominiumGetReceitaFederalDataQuery, Result<CondominiumReceitaFederalDto>>
{
    private readonly IHttpClient<string[], CondominiumReceitaFederalDto> _httpClient = httpClient;

    public async Task<Result<CondominiumReceitaFederalDto>> Handle(
        CondominiumGetReceitaFederalDataQuery request,
        CancellationToken cancellationToken
    )
    {
        if (request is null || request.Parameters.IsNullOrEmpty())
        {
            return Result<CondominiumReceitaFederalDto>.RequestFailed();
        }

        var result = await this._httpClient.SendAsync(
            request.Parameters,
            HttpClientSettingsEnum.ReceitaWS
        );

        return Result<CondominiumReceitaFederalDto>.RequestOk(result);
    }
}
