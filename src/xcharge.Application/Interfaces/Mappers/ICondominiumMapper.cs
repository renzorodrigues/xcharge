using xcharge.Application.CQS.Commands.CondominiumCommand;
using xcharge.Application.DTOs.Condominium.Responses;

namespace xcharge.Application.Interfaces.Mappers.Condominium;

public interface ICondominiumMapper
    : IMapper<CondominiumCreateCommand, Domain.Entities.Condominium>,
        IMapper<Domain.Entities.Condominium, CondominiumGetByIdDto>,
        IMapper<IEnumerable<Domain.Entities.Condominium>, IEnumerable<CondominiumGetAllDto>> { }
