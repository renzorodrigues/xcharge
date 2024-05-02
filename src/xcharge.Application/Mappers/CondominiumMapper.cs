using System.Globalization;
using xcharge.Application.CQS.Commands.CondominiumCommand;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Domain.Enums;

namespace xcharge.Application.Mappers;

public class CondominiumMapper(
    IAddressMapper addressMapper,
    IEmailMapper emailMapper,
    ITelephoneMapper telephoneMapper,
    IIdLegalPersonMapper idLegalPersonMapper
) : ICondominiumMapper
{
    private readonly IAddressMapper _addressMapper = addressMapper;
    private readonly IEmailMapper _emailMapper = emailMapper;
    private readonly ITelephoneMapper _telephoneMapper = telephoneMapper;
    private readonly IIdLegalPersonMapper _idLegalPersonMapper = idLegalPersonMapper;

    public CondominiumGetByIdDto Map(Domain.Entities.Condominium entity)
    {
        return new CondominiumGetByIdDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            AddressPublicArea = entity.Address?.PublicArea,
            AddressNumber = entity.Address?.Number,
            AddressComplement = entity.Address?.Complement,
            AddressZipCode = entity.Address?.ZipCode,
            AddressDistrict = entity.Address?.District,
            AddressCity = entity.Address?.City,
            AddressState = entity.Address?.State,
            IdCnpj = entity.Identification?.Cnpj,
            IdCityRegistration = entity.Identification?.CityRegistration,
            IdStateRegistration = entity.Identification?.StateRegistration,
            Email = entity.Email?.EmailAddress,
            Landline = entity.Telephone?.Landline,
            Mobile = entity.Telephone?.Mobile,
        };
    }

    public Domain.Entities.Condominium Map(CondominiumCreateCommand request)
    {
        return new Domain.Entities.Condominium(
            CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(request.Name!),
            this._addressMapper.Map(request.Address),
            this._emailMapper.Map(request.Email),
            this._telephoneMapper.Map((request.Landline, request.Mobile)),
            this._idLegalPersonMapper.Map(request.Cnpj!)
        );
    }

    public IEnumerable<CondominiumGetAllDto> Map(IEnumerable<Domain.Entities.Condominium> source)
    {
        IList<CondominiumGetAllDto> responses = [];

        foreach (var condominium in source)
        {
            var (landline, mobile) = this._telephoneMapper.Map(condominium.Telephone!);

            var manager = condominium.AppUserCondominiums is null
                ? null
                : condominium
                    .AppUserCondominiums?.FirstOrDefault(x => x.UserType == UserType.Manager)
                    ?.AppUser?.FullName;

            responses.Add(
                new CondominiumGetAllDto()
                {
                    Id = condominium.Id,
                    Name = condominium.Name,
                    Manager = manager,
                    Landline = landline,
                    Mobile = mobile,
                    Email = condominium.Email?.EmailAddress,
                    City = condominium.Address?.City,
                }
            );
        }

        return responses;
    }
}
