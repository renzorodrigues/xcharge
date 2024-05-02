using MediatR;
using xcharge.Shared.Helpers;

namespace xcharge.Shared.Handlers.Interfaces;

public interface ICommand<TResult> : IRequest<Result<TResult>> { }
