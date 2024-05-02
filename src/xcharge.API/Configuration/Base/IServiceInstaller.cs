namespace xcharge.API.Configuration.Base;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
