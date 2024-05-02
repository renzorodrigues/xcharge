using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Queries.Condominium;

public class UserGetByIdQuery(Guid id) : Query<UserGetByIdDto>
{
    public Guid Id { get; set; } = id;
}
