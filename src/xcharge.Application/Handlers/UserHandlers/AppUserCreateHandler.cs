using System.Net;
using MediatR;
using xcharge.Application.CQS.Commands.UserCommand;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Domain.Entities.Base;
using xcharge.Shared.Helpers;
using xcharge.Shared.Validations;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.UserHandlers;

public class AppUserCreateHandler(
    IUserRepository userRepository,
    ICondominiumRepository condominiumRepository,
    IValidator validator,
    IUserMapper userMapper
) : IRequestHandler<UserCreateCommand, Result<Guid>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ICondominiumRepository _condominiumRepository = condominiumRepository;
    private readonly IValidator _validator = validator;
    private readonly IUserMapper _userMapper = userMapper;

    public async Task<Result<Guid>> Handle(
        UserCreateCommand request,
        CancellationToken cancellationToken
    )
    {
        if (request is null)
        {
            return Result<Guid>.RequestFailed();
        }

        var condominium = await this._condominiumRepository.GetById(request.CondominiumId);

        if (condominium is null)
        {
            return Result<Guid>.RequestFailed();
        }

        var appUser = this._userMapper.Map(request);

        var appUserCondominium = new AppUserCondominium(appUser.Id, condominium.Id, appUser.Type);

        appUser.AppUserCondominiums?.Add(appUserCondominium);

        var result = await this._userRepository.Create(appUser);

        return Result<Guid>.RequestOk(result, Response.CreatedSuccessfully, HttpStatusCode.Created);
    }
}
