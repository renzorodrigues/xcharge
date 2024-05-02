using System.ComponentModel.DataAnnotations;
using xcharge.Application.ViewModel;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Commands.CondominiumCommand;

public record CondominiumCreateCommand : Command<Guid>
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Cnpj { get; set; }
    public EmailModel? Email { get; set; }
    public AddressModel? Address { get; set; }
    public string? Landline { get; set; }

    [Required]
    public string? Mobile { get; set; }
}
