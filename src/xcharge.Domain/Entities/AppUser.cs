using xcharge.Domain.Entities.Base;
using xcharge.Domain.Enums;
using xcharge.Domain.ValueObjects;

namespace xcharge.Domain.Entities;

public class AppUser : BaseEntity
{
    public AppUser() { }

    public AppUser(
        string? fullName,
        DateTime birthdate,
        string? placeOfBirth,
        string? nationality,
        UserType type,
        IdNaturalPerson? identification,
        Address? address,
        Email? email,
        Telephone? telephone,
        IList<AppUserCondominium>? appUserCondominiums
    )
    {
        this.FullName = fullName;
        this.Birthdate = birthdate;
        this.PlaceOfBirth = placeOfBirth;
        this.Nationality = nationality;
        this.Identification = identification;
        this.Type = type;
        this.Address = address;
        this.Email = email;
        this.Telephone = telephone;
        this.AppUserCondominiums = appUserCondominiums;
    }

    public string? FullName { get; private set; }
    public DateTime Birthdate { get; private set; }
    public string? PlaceOfBirth { get; private set; }
    public string? Nationality { get; private set; }
    public IdNaturalPerson? Identification { get; private set; }
    public UserType Type { get; private set; }
    public Address? Address { get; private set; }
    public Email? Email { get; private set; }
    public Telephone? Telephone { get; private set; }
    public IList<AppUserCondominium>? AppUserCondominiums { get; private set; } = [];
}
