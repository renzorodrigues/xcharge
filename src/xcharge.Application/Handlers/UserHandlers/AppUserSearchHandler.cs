using System.Net;
using MediatR;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Shared.Helpers;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class AppUserSearchHandler(IUserRepository repository)
    : IRequestHandler<UserSearchQuery, Result<IEnumerable<AppUserSearchDto>>>
{
    private readonly IUserRepository _repository = repository;

    public async Task<Result<IEnumerable<AppUserSearchDto>>> Handle(
        UserSearchQuery request,
        CancellationToken cancellationToken
    )
    {
        if (request is null || string.IsNullOrEmpty(request.Name))
        {
            return Result<IEnumerable<AppUserSearchDto>>.RequestFailed();
        }

        var users = await this._repository.GetAllPaged(request.Name);

        if (users is null)
        {
            return Result<IEnumerable<AppUserSearchDto>>.RequestFailed(
                Response.ObjectNotFound,
                HttpStatusCode.NotFound
            );
        }

        return Result<IEnumerable<AppUserSearchDto>>.RequestOk(users);
    }
}
