using xcharge.Domain.Entities.Base;
using xcharge.Domain.ValueObjects;

namespace xcharge.Domain.Entities;

public class Tenant : BaseEntity
{
    public Tenant() { }

    public Tenant(
        string? name,
        Address? address,
        IdLegalPerson? identification,
        Email? email,
        Telephone? telephone,
        bool isActive,
        IEnumerable<Condominium>? condominiums
    )
    {
        this.Name = name;
        this.Address = address;
        this.Identification = identification;
        this.Email = email;
        this.Telephone = telephone;
        this.IsActive = isActive;
        this.Condominiums = condominiums;
    }

    public string? Name { get; private set; }
    public Address? Address { get; private set; }
    public IdLegalPerson? Identification { get; set; }
    public Email? Email { get; private set; }
    public Telephone? Telephone { get; private set; }
    public bool IsActive { get; private set; } = false;
    public IEnumerable<Condominium>? Condominiums { get; private set; }
}
