namespace xcharge.Application.DTOs.Unit.Responses;

public record UnitDto
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? Size { get; set; }
    public bool IsRented { get; set; }
    public bool IsForRent { get; set; }
    public string? Owner { get; set; }
    public bool? Tenant { get; set; }
}
