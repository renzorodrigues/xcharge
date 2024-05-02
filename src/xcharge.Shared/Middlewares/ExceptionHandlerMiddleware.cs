using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using xcharge.Shared.Helpers;
using xcharge.Shared.Validations;

namespace xcharge.Shared.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            ValidationException.Errors.Clear();
            //context.Request.EnableBuffering();
            //var stream = context.Request.Body;

            //using var reader = new StreamReader(stream);
            //var requestBodyAsString = await reader.ReadToEndAsync();

            //var userRequest = Deserialize<UserRequest>(requestBodyAsString);

            //userRequest!.Validate();

            //if (stream.CanSeek)
            //    stream.Seek(0, SeekOrigin.Begin);

            await next(context);
        }
        catch (ValidationException ex)
        {
            var result = new CustomResult()
            {
                StatusCode = ValidationException.StatusCode,
                Errors = ValidationException.Errors,
                Message = ex.Message,
                IsSuccess = false,
            };

            context.Response.ContentType = ConstantStrings.Headers.ApplicationJson;
            context.Response.StatusCode = (int)result.StatusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
        catch (Exception ex)
        {
            var exceptionErrorMessage = ex.InnerException is null
                ? ex.StackTrace
                : $"{ex.InnerException.Message} - Source: {ex.InnerException.Source}";

            var result = new CustomResult()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Errors = [new(exceptionErrorMessage)],
                Message = ex.Message,
                IsSuccess = false,
            };

            context.Response.ContentType = ConstantStrings.Headers.ApplicationJson;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
