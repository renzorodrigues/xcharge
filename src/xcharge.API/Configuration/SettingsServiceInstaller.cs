using xcharge.API.Configuration.Base;
using xcharge.Shared.Settings.HttpClientSettings;

namespace xcharge.API.Configuration;

public class SettingsServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var httpClientSettings = new HttpClientSettings();
        configuration.Bind("HttpClientSettings", httpClientSettings);

        services.AddSingleton(httpClientSettings);
    }
}
