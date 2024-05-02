using xcharge.Application.DTOs.Condominium.Responses;

namespace xcharge.Application.Interfaces.Mappers.Responses;

public interface ICondominiumGetAllMapper
{
    IEnumerable<CondominiumGetAllDto> Map(IEnumerable<Domain.Entities.Condominium> entities);
}
