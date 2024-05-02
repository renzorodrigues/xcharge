using System.Net;
using AutoFixture;
using FluentAssertions;
using Moq;
using xcharge.Application.CQS.Commands.UserCommand;
using xcharge.Application.Handlers.UserHandlers;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Application.Tests.FakeData;
using xcharge.Domain.Entities;
using xcharge.Shared.Validations;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Tests.Handlers.UserHandlers;

public class UserCreateHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<ICondominiumRepository> _condominiumRepositoryMock;
    private readonly Mock<IValidator> _validatorMock;
    private readonly Mock<IUserMapper> _userMapperMock;
    private readonly AppUserCreateHandler _userCreateHandler;
    private readonly Fixture _fixture;

    public UserCreateHandlerTests()
    {
        this._userRepositoryMock = new Mock<IUserRepository>();
        this._condominiumRepositoryMock = new Mock<ICondominiumRepository>();
        this._validatorMock = new Mock<IValidator>();
        this._userMapperMock = new Mock<IUserMapper>();
        this._userCreateHandler = new AppUserCreateHandler(
            this._userRepositoryMock.Object,
            this._condominiumRepositoryMock.Object,
            this._validatorMock.Object,
            this._userMapperMock.Object
        );
        this._fixture = new();
    }

    [Fact]
    public async void Handler_RequestIsNull_ShouldReturnBadRequest()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();

        // Act
        var result = await this._userCreateHandler.Handle(null, cancellationToken);

        // Assert
        result.Data.Should().BeEmpty();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async void Handler_CondominiumIsNull_ShouldReturnBadRequest()
    {
        // Arrange
        var userCreateCommand = this._fixture.Create<UserCreateCommand>();
        var cancellationToken = this._fixture.Create<CancellationToken>();

        // Act
        var result = await this._userCreateHandler.Handle(userCreateCommand, cancellationToken);

        // Assert
        result.Data.Should().BeEmpty();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async void Handler_Success_ShouldReturnOk()
    {
        // Arrange
        var userCreateCommand = this._fixture.Create<UserCreateCommand>();
        var cancellationToken = this._fixture.Create<CancellationToken>();

        var condominium = EntityBuilder.CondominiumBuilder();

        var appUser = EntityBuilder.AppUserBuilder();

        this._condominiumRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(condominium);

        this._userMapperMock.Setup(x => x.Map(It.IsAny<UserCreateCommand>())).Returns(appUser);

        this._userRepositoryMock.Setup(x => x.Create(It.IsAny<AppUser>()))
            .ReturnsAsync(Guid.NewGuid());

        // Act
        var result = await this._userCreateHandler.Handle(userCreateCommand, cancellationToken);

        // Assert
        result.Data.Should().NotBeEmpty();
        result.IsSuccess.Should().BeTrue();
        result.Message.Should().Be(Response.CreatedSuccessfully);
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}
