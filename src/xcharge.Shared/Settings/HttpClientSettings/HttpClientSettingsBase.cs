namespace xcharge.Shared.Settings;

public class HttpClientSettingsBase
{
    public HttpClientSettingsBase() { }

    public HttpClientSettingsBase(string baseAddress, string requestUri)
    {
        this.BaseAddress = baseAddress;
        this.RequestUri = requestUri;
    }

    public string BaseAddress { get; set; }
    public string RequestUri { get; set; }
}
