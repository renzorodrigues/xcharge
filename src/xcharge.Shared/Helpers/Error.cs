namespace xcharge.Shared.Helpers;

public class Error(string errorMessage)
{
    public string Message { get; } = errorMessage;
}
