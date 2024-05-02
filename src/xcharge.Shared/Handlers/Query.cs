using xcharge.Shared.Handlers.Interfaces;

namespace xcharge.Shared.Handlers;

public abstract class Query<TResult> : IQuery<TResult>
{
    public Guid RequestId { get; set; }
}
