using xcharge.Application.Interfaces.Mappers;
using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Mappers.ValueObjects;

public class TelephoneMapper : ITelephoneMapper
{
    public Telephone Map((string? landline, string? mobile) telephone)
    {
        return new Telephone(telephone.landline!, telephone.mobile!);
    }

    public (string? landline, string? mobile) Map(Telephone? telephone)
    {
        return (telephone?.Landline, telephone?.Mobile);
    }
}
