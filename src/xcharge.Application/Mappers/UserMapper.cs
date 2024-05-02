using System.Globalization;
using xcharge.Application.CQS.Commands.UserCommand;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Domain.Entities;
using xcharge.Domain.Enums;

namespace xcharge.Application.Mappers;

public class UserMapper(
    IAddressMapper addressMapper,
    ITelephoneMapper telephoneMapper,
    IEmailMapper emailMapper,
    IIdNaturalPersonMapper naturalPersonMapper
) : IUserMapper
{
    private readonly IAddressMapper _addressMapper = addressMapper;
    private readonly ITelephoneMapper _telephoneMapper = telephoneMapper;
    private readonly IEmailMapper _emailMapper = emailMapper;
    private readonly IIdNaturalPersonMapper _naturalPersonMapper = naturalPersonMapper;

    public UserGetByIdDto Map(AppUser source)
    {
        return new UserGetByIdDto()
        {
            Id = source.Id,
            FullName = source.FullName,
            Birthdate = source.Birthdate.ToString("dd/MM/yyyy"),
            PlaceOfBirth = source.PlaceOfBirth,
            Nationality = source.Nationality,
            Cpf = source.Identification?.Cpf,
            Rg = source.Identification?.Rg,
            Pis = source.Identification?.Pis,
            UserType = source.Type.ToString(),
            AddressPublicArea = source.Address?.PublicArea,
            AddressComplement = source.Address?.Complement,
            AddressDistrict = source.Address?.District,
            AddressZipCode = source.Address?.ZipCode,
            AddressCity = source.Address?.City,
            AddressState = source.Address?.State,
            Email = source.Email?.EmailAddress,
            Landline = source.Telephone?.Landline,
            Mobile = source.Telephone?.Mobile,
        };
    }

    public AppUser Map(UserCreateCommand source)
    {
        var typeIsValid = Enum.TryParse(source.Type, out UserType type);

        if (!typeIsValid)
        {
            type = UserType.None;
        }

        return new AppUser(
            CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(source.FullName!),
            source.Birthdate,
            source.PlaceOfBirth,
            source.Nationality,
            type,
            this._naturalPersonMapper.Map(source.Identification),
            this._addressMapper.Map(source.Address),
            this._emailMapper.Map(source.Email),
            this._telephoneMapper.Map((source.Landline, source.Mobile)),
            []
        );
    }
}
