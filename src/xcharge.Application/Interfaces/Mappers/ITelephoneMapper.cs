using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Interfaces.Mappers;

public interface ITelephoneMapper
    : IMapper<(string? landline, string? mobile), Telephone>,
        IMapper<Telephone, (string? landline, string? mobile)> { }
