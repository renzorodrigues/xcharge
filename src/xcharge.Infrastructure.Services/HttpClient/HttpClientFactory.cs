using System.Text.Json;
using xcharge.Application.Extensions;
using xcharge.Application.Interfaces.Services;
using xcharge.Shared.Helpers;
using xcharge.Shared.Settings;
using xcharge.Shared.Settings.HttpClientSettings;

namespace xcharge.Infrastructure.Services.HttpClient;

public class HttpClientFactory<TRequest, TResponse>(
    IHttpClientFactory httpClientFactory,
    HttpClientSettings httpClientSettings
) : IHttpClient<TRequest, TResponse>
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly HttpClientSettings _httpClientSettings = httpClientSettings;

    public HttpClientSettingsEnum HttpClientEnum { get; private set; }

    public async Task<TResponse> SendAsync(TRequest request, HttpClientSettingsEnum httpClientEnum)
    {
        this.HttpClientEnum = httpClientEnum;

        return await this.CreateClient(request);
    }

    private async Task<TResponse> CreateClient(TRequest request)
    {
        var settings =
            this.GetSettings(this.HttpClientEnum)
            ?? throw new ArgumentNullException(nameof(request));

        var client = this._httpClientFactory.CreateClient();

        client.BaseAddress = new Uri(settings.BaseAddress);

        var response = await CreateRequest(request, client, settings);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(content)!;
        }
        else
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
    }

    private static async Task<HttpResponseMessage> CreateRequest(
        TRequest request,
        System.Net.Http.HttpClient client,
        HttpClientSettingsBase settings
    )
    {
        Type type = typeof(TRequest);

        if (type == typeof(string[])) // GET
        {
            var parameters = request as string[];

            string requestUri;

            if (!parameters.IsNullOrEmpty())
            {
                requestUri =
                    $"{client.BaseAddress}{string.Format(settings.RequestUri, parameters!)}";
            }
            else
            {
                requestUri = $"{client.BaseAddress}{settings.RequestUri}";
            }

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

            return await client.SendAsync(httpRequestMessage);
        }
        else // POST
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, settings.RequestUri);
            var json = JsonSerializer.Serialize(request);
            httpRequestMessage.Content = new StringContent(
                json,
                null,
                ConstantStrings.Headers.ApplicationJson
            );

            return await client.SendAsync(httpRequestMessage);
        }
    }

    private HttpClientSettingsBase? GetSettings(HttpClientSettingsEnum httpClientEnum)
    {
        return httpClientEnum switch
        {
            HttpClientSettingsEnum.BankSlipIssue
                => new(
                    this._httpClientSettings.BankSlipIssue.BaseAddress,
                    this._httpClientSettings.BankSlipIssue.RequestUri
                ),
            HttpClientSettingsEnum.ReceitaWS
                => new(
                    this._httpClientSettings.ReceitaWS.BaseAddress,
                    this._httpClientSettings.ReceitaWS.RequestUri
                ),
            _ => null,
        };
    }
}
