using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Queries.Condominium;

public class CondominiumGetAllQuery : Query<IEnumerable<CondominiumGetAllDto>> { }
