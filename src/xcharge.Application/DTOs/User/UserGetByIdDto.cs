namespace xcharge.Application.DTOs.Condominium.Responses;

public record UserGetByIdDto
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Birthdate { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? Nationality { get; set; }
    public string? Cpf { get; set; }
    public string? Rg { get; set; }
    public string? Pis { get; set; }
    public string? UserType { get; set; }
    public string? AddressPublicArea { get; set; }
    public string? AddressComplement { get; set; }
    public string? AddressDistrict { get; set; }
    public string? AddressCity { get; set; }
    public string? AddressState { get; set; }
    public string? AddressZipCode { get; set; }
    public string? Email { get; set; }
    public string? Landline { get; set; }
    public string? Mobile { get; set; }
}
