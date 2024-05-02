using xcharge.API.Configuration.Base;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Application.Interfaces.Mappers.Responses;
using xcharge.Application.Mappers;
using xcharge.Application.Mappers.BankSlip;
using xcharge.Application.Mappers.Block.Responses;
using xcharge.Application.Mappers.ValueObjects;

namespace xcharge.API.Configuration;

public class MappersServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IBankSlipIssueMapper, BankSlipIssueMapper>();
        services.AddTransient<ICondominiumMapper, CondominiumMapper>();
        services.AddTransient<IUserMapper, UserMapper>();
        services.AddTransient<IBlockGetByIdMapper, BlockGetByIdMapper>();
        services.AddTransient<IIdLegalPersonMapper, IdLegalPersonMapper>();
        services.AddTransient<IIdNaturalPersonMapper, IdNaturalPersonMapper>();
        services.AddTransient<ITelephoneMapper, TelephoneMapper>();
        services.AddTransient<IAddressMapper, AddressMapper>();
        services.AddTransient<IEmailMapper, EmailMapper>();
    }
}
