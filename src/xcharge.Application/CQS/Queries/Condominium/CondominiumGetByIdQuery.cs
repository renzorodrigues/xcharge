using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Queries.Condominium;

public class CondominiumGetByIdQuery(Guid id) : Query<CondominiumGetByIdDto>
{
    public Guid Id { get; set; } = id;
}
