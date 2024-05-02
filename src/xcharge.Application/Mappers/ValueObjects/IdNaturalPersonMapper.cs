using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.ViewModel;
using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Mappers.ValueObjects;

public class IdNaturalPersonMapper : IIdNaturalPersonMapper
{
    public IdNaturalPerson Map(IdNaturalPersonModel? source)
    {
        return new IdNaturalPerson(source?.Cpf, source?.Rg, source?.Pis);
    }
}
