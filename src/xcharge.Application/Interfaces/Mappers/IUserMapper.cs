using xcharge.Application.CQS.Commands.UserCommand;
using xcharge.Application.DTOs.Condominium.Responses;

namespace xcharge.Application.Interfaces.Mappers;

public interface IUserMapper
    : IMapper<Domain.Entities.AppUser, UserGetByIdDto>,
        IMapper<UserCreateCommand, Domain.Entities.AppUser> { }
