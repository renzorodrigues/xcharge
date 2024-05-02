using System.Text.Json.Serialization;
using xcharge.Shared.Handlers.Interfaces;

namespace xcharge.Shared.Handlers;

public record Command<TResult> : ICommand<TResult>
{
    [JsonIgnore]
    public Guid RequestId { get; set; } = Guid.NewGuid();
}
