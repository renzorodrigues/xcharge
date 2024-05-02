using System.Net;
using MediatR;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Shared.Helpers;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class CondominiumGetByIdHandler(ICondominiumRepository repository, ICondominiumMapper mapper)
    : IRequestHandler<CondominiumGetByIdQuery, Result<CondominiumGetByIdDto>>
{
    private readonly ICondominiumRepository _repository = repository;
    private readonly ICondominiumMapper _mapper = mapper;

    public async Task<Result<CondominiumGetByIdDto>> Handle(
        CondominiumGetByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        if (request is null || request.Id == Guid.Empty)
        {
            return Result<CondominiumGetByIdDto>.RequestFailed();
        }

        var condominium = await this._repository.GetById(request.Id);

        if (condominium is null)
        {
            return Result<CondominiumGetByIdDto>.RequestFailed(
                Response.ObjectNotFound,
                HttpStatusCode.NotFound
            );
        }

        var response = this._mapper.Map(condominium);

        return Result<CondominiumGetByIdDto>.RequestOk(response);
    }
}
