using xcharge.Domain.Entities.Base;
using xcharge.Domain.ValueObjects;

namespace xcharge.Domain.Entities;

public sealed class Condominium : BaseEntity
{
    private Condominium() { }

    public Condominium(
        string? name,
        Address? address,
        Email? email,
        Telephone? telephone,
        IdLegalPerson? identification
    )
    {
        this.Name = name;
        this.Address = address;
        this.Email = email;
        this.Telephone = telephone;
        this.Identification = identification;
    }

    public string? Name { get; private set; }
    public Address? Address { get; private set; }
    public Email? Email { get; private set; }
    public Telephone? Telephone { get; private set; }
    public IdLegalPerson? Identification { get; private set; }
    public IList<AppUserCondominium>? AppUserCondominiums { get; private set; } = [];
    public Tenant? Tenant { get; private set; }

    public void AddManager(Condominium condominium, AppUser user)
    {
        //condominium.AppUserCondominiums?.Add(user);
        condominium.UpdatedAt = DateTime.Now;
    }
}
