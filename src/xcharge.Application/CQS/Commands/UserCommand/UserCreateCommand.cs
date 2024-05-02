using System.ComponentModel.DataAnnotations;
using xcharge.Application.ViewModel;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Commands.UserCommand;

public record UserCreateCommand : Command<Guid>
{
    [Required]
    public string? FullName { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? Nationality { get; set; }

    [Required]
    public DateTime Birthdate { get; set; }

    [Required]
    public string? Type { get; set; }
    public EmailModel? Email { get; set; }
    public IdNaturalPersonModel? Identification { get; set; }
    public AddressModel? Address { get; set; }
    public string? Landline { get; set; }

    [Required]
    public string? Mobile { get; set; }
    public Guid CondominiumId { get; set; }
}
