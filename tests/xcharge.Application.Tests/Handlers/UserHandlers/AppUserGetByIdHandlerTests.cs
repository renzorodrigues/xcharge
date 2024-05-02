using System.Net;
using AutoFixture;
using FluentAssertions;
using Moq;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Handlers.CondominiumHandlers;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Application.Tests.FakeData;
using xcharge.Domain.Entities;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Tests.Handlers.UserHandlers;

public class UserGetByIdHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IUserMapper> _userMapperMock;
    private readonly AppUserGetByIdHandler _userGetByIdHandler;
    private readonly Fixture _fixture;

    public UserGetByIdHandlerTests()
    {
        this._userRepositoryMock = new Mock<IUserRepository>();
        this._userMapperMock = new Mock<IUserMapper>();
        this._userGetByIdHandler = new AppUserGetByIdHandler(
            this._userRepositoryMock.Object,
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
        var result = await this._userGetByIdHandler.Handle(null, cancellationToken);

        // Assert
        result.Data.Should().BeNull();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async void Handler_IdIsEmpty_ShouldReturnBadRequest()
    {
        // Arrange
        var userGetByIdQuery = this
            ._fixture.Build<UserGetByIdQuery>()
            .With(x => x.Id, Guid.Empty)
            .Create();

        var cancellationToken = this._fixture.Create<CancellationToken>();

        // Act
        var result = await this._userGetByIdHandler.Handle(userGetByIdQuery, cancellationToken);

        // Assert
        result.Data.Should().BeNull();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async void Handler_AppUserIsNull_ShouldReturnNotFound()
    {
        // Arrange
        var userGetByIdQuery = this._fixture.Create<UserGetByIdQuery>();

        var cancellationToken = this._fixture.Create<CancellationToken>();

        AppUser appUser = null;

        this._userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(appUser);

        // Act
        var result = await this._userGetByIdHandler.Handle(userGetByIdQuery, cancellationToken);

        // Assert
        result.Data.Should().BeNull();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.ObjectNotFound);
        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async void Handler_Success_ShouldReturnOk()
    {
        // Arrange
        var userGetByIdQuery = this._fixture.Create<UserGetByIdQuery>();
        var cancellationToken = this._fixture.Create<CancellationToken>();
        var userGetByIdDto = this._fixture.Create<UserGetByIdDto>();

        AppUser appUser = EntityBuilder.AppUserBuilder();

        this._userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(appUser);

        this._userMapperMock.Setup(x => x.Map(It.IsAny<AppUser>())).Returns(userGetByIdDto);

        // Act
        var result = await this._userGetByIdHandler.Handle(userGetByIdQuery, cancellationToken);

        // Assert
        result.Data.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Message.Should().Be(Response.RequestSuccessfully);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
