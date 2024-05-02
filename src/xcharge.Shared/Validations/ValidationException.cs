using System.Net;
using xcharge.Shared.Helpers;

namespace xcharge.Shared.Validations;

public class ValidationException(string message) : Exception(message)
{
    public static IList<Error> Errors { get; set; } = [];
    public static HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
}
