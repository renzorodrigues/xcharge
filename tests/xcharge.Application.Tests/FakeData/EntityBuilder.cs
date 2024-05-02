using xcharge.Domain.Entities;
using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Tests.FakeData;

public static class EntityBuilder
{
    public static AppUser AppUserBuilder()
    {
        return new AppUser(
            "Teste da Silva",
            DateTime.Now.AddYears(-25),
            "São Paulo",
            "Brasileiro",
            Domain.Enums.UserType.Manager,
            IdNaturalPersonBuilder(),
            AddressBuilder(),
            EmailBuilder(),
            TelephoneBuilder(),
            []
        );
    }

    public static Condominium CondominiumBuilder()
    {
        return new Condominium(
            "Condomínio Teste",
            AddressBuilder(),
            EmailBuilder(),
            TelephoneBuilder(),
            IdLegalPersonBuilder()
        );
    }

    public static Address AddressBuilder()
    {
        return new Address(
            "Rua Teste",
            "123",
            "Bloco B - 501",
            "Centro",
            "38400-000",
            "MG",
            "Uberlândia"
        );
    }

    public static Telephone TelephoneBuilder()
    {
        return new Telephone("3432334455", "34991238899");
    }

    public static Email EmailBuilder()
    {
        return new Email("teste@email.com");
    }

    public static IdLegalPerson IdLegalPersonBuilder()
    {
        return new IdLegalPerson("45459181000157", "7733796243361", "8889735002071");
    }

    public static IdNaturalPerson IdNaturalPersonBuilder()
    {
        return new IdNaturalPerson("88785025020", "12228410", "90797196035");
    }
}
