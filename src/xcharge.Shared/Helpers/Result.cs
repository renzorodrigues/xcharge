using System.Net;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Shared.Helpers;

public class Result<T> : CustomResult
{
    public T Data { get; set; }

    public static Result<T> RequestOk(
        T data,
        string message = Response.RequestSuccessfully,
        HttpStatusCode statusCode = HttpStatusCode.OK
    )
    {
        return new()
        {
            Data = data,
            Message = message,
            IsSuccess = true,
            StatusCode = statusCode,
        };
    }

    public static Result<T> RequestFailed(
        string message = Response.RequestFailed,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        IEnumerable<Error> errors = null
    )
    {
        return new()
        {
            Message = message,
            Errors = errors,
            IsSuccess = false,
            StatusCode = statusCode,
        };
    }
}
