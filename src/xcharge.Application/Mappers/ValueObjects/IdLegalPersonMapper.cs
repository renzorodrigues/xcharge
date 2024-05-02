using xcharge.Application.Interfaces.Mappers;
using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Mappers.ValueObjects;

public class IdLegalPersonMapper : IIdLegalPersonMapper
{
    public IdLegalPerson Map(string source)
    {
        return new IdLegalPerson(source, string.Empty, string.Empty);
    }
}
