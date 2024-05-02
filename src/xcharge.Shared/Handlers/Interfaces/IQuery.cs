using MediatR;
using xcharge.Shared.Helpers;

namespace xcharge.Shared.Handlers.Interfaces;

public interface IQuery<TResult> : IRequest<Result<TResult>> { }
