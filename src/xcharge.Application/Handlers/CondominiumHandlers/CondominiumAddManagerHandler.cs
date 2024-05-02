using System.Net;
using MediatR;
using xcharge.Application.CQS.Commands.CondominiumCommand;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Domain.Entities.Base;
using xcharge.Domain.Enums;
using xcharge.Shared.Helpers;
using xcharge.Shared.Validations;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class CondominiumAddManagerHandler(
    ICondominiumRepository condominiumRepository,
    IValidator validator
) : IRequestHandler<AddManagerCommand, Result<Guid>>
{
    private readonly IValidator _validator = validator;
    private readonly ICondominiumRepository _condominiumRepository = condominiumRepository;

    public async Task<Result<Guid>> Handle(
        AddManagerCommand request,
        CancellationToken cancellationToken
    )
    {
        if (!IsValid(request))
        {
            return Result<Guid>.RequestFailed();
        }

        var condominium = await this._condominiumRepository.GetById(request.CondominiumId);

        if (condominium is null)
        {
            return Result<Guid>.RequestFailed(
                Response.CondominiumNotFound,
                HttpStatusCode.NotFound
            );
        }

        var appUserCondominium = new AppUserCondominium(
            request.UserId,
            request.CondominiumId,
            UserType.Manager
        );

        condominium.AppUserCondominiums?.Add(appUserCondominium);

        var result = await this._condominiumRepository.Update(condominium);

        return Result<Guid>.RequestOk(result, Response.UpdatedSuccessfully);
    }

    private static bool IsValid(AddManagerCommand request)
    {
        if (request is null || request.CondominiumId == Guid.Empty || request.UserId == Guid.Empty)
        {
            return false;
        }

        return true;
    }
}
