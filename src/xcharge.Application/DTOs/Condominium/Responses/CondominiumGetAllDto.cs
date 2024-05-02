using xcharge.Application.DTOs.Telephone;

namespace xcharge.Application.DTOs.Condominium.Responses;

public record CondominiumGetAllDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Manager { get; set; }
    public string? Landline { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? City { get; set; }
}
