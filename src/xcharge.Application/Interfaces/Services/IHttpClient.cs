using xcharge.Shared.Settings.HttpClientSettings;

namespace xcharge.Application.Interfaces.Services;

public interface IHttpClient<TRequest, TResponse>
{
    Task<TResponse> SendAsync(TRequest request, HttpClientSettingsEnum httpClientEnum);
}
