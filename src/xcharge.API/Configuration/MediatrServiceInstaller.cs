using xcharge.API.Configuration.Base;
using xcharge.Application.CQS.Commands.BankSlipCommand;
using xcharge.Application.CQS.Commands.CondominiumCommand;

namespace xcharge.API.Configuration;

public class MediatrServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(m => m.RegisterServicesFromAssemblyContaining(typeof(Program)));
        services.AddMediatR(m =>
            m.RegisterServicesFromAssemblyContaining(typeof(BankSlipIssueCommand))
        );
        services.AddMediatR(m =>
            m.RegisterServicesFromAssemblyContaining(typeof(CondominiumCreateCommand))
        );
    }
}
