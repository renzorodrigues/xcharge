using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.ViewModel;
using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Mappers.ValueObjects;

public class AddressMapper : IAddressMapper
{
    public Address Map(AddressModel? source)
    {
        return new Address(
            source?.PublicArea,
            source?.Number,
            source?.Complement,
            source?.District,
            source?.ZipCode,
            source?.State,
            source?.City
        );
    }
}
