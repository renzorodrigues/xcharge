using MediatR;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Extensions;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Shared.Helpers;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class CondominiumGetAllHandler(
    ICondominiumRepository repository,
    ICondominiumMapper condominiumMapper
) : IRequestHandler<CondominiumGetAllQuery, Result<IEnumerable<CondominiumGetAllDto>>>
{
    private readonly ICondominiumRepository _repository = repository;
    private readonly ICondominiumMapper _condominiumMapper = condominiumMapper;

    public async Task<Result<IEnumerable<CondominiumGetAllDto>>> Handle(
        CondominiumGetAllQuery request,
        CancellationToken cancellationToken
    )
    {
        var condominiums = await this._repository.GetAll();

        if (condominiums.IsNullOrEmpty())
        {
            return Result<IEnumerable<CondominiumGetAllDto>>.RequestOk(
                [],
                Response.NoRecordsToBeRetrieved
            );
        }

        var result = this._condominiumMapper.Map(condominiums);

        return Result<IEnumerable<CondominiumGetAllDto>>.RequestOk(result);
    }
}
