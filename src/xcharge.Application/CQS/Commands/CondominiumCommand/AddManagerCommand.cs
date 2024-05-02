using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Commands.CondominiumCommand;

public record AddManagerCommand : Command<Guid>
{
    public Guid CondominiumId { get; set; }
    public Guid UserId { get; set; }
}
