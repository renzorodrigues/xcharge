using System.ComponentModel.DataAnnotations;

namespace xcharge.Application.ViewModel;

public record EmailModel
{
    [Required]
    public string? EmailAddress { get; set; }
}
