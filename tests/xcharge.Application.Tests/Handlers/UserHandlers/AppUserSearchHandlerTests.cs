using System.Net;
using AutoFixture;
using FluentAssertions;
using Moq;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Handlers.CondominiumHandlers;
using xcharge.Application.Interfaces.Repositories;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Tests.Handlers.UserHandlers;

public class UserSearchHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly AppUserSearchHandler _userSearchHandler;
    private readonly Fixture _fixture;

    public UserSearchHandlerTests()
    {
        this._userRepositoryMock = new Mock<IUserRepository>();
        this._userSearchHandler = new AppUserSearchHandler(this._userRepositoryMock.Object);
        this._fixture = new();
    }

    [Fact]
    public async void Handler_RequestIsNull_ShouldReturnBadRequest()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();

        // Act
        var result = await this._userSearchHandler.Handle(null, cancellationToken);

        // Assert
        result.Data.Should().BeNull();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async void Handler_RequestIsNullOrEmpty_ShouldReturnBadRequest(string name)
    {
        // Arrange
        var userSearchQuery = this
            ._fixture.Build<UserSearchQuery>()
            .With(x => x.Name, name)
            .Create();

        var cancellationToken = this._fixture.Create<CancellationToken>();

        // Act
        var result = await this._userSearchHandler.Handle(userSearchQuery, cancellationToken);

        // Assert
        result.Data.Should().BeNull();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async void Handler_UserListIsNull_ShouldReturnNotFound()
    {
        // Arrange
        var userSearchQuery = this._fixture.Create<UserSearchQuery>();
        var cancellationToken = this._fixture.Create<CancellationToken>();
        IEnumerable<AppUserSearchDto> appUserSearchDtoList = null;

        this._userRepositoryMock.Setup(x => x.GetAllPaged(It.IsAny<string>()))
            .ReturnsAsync(appUserSearchDtoList);

        // Act
        var result = await this._userSearchHandler.Handle(userSearchQuery, cancellationToken);

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
        var userSearchQuery = this._fixture.Create<UserSearchQuery>();
        var cancellationToken = this._fixture.Create<CancellationToken>();
        var appUserSearchDtoList = this._fixture.CreateMany<AppUserSearchDto>();

        this._userRepositoryMock.Setup(x => x.GetAllPaged(It.IsAny<string>()))
            .ReturnsAsync(appUserSearchDtoList);

        // Act
        var result = await this._userSearchHandler.Handle(userSearchQuery, cancellationToken);

        // Assert
        result.Data.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Message.Should().Be(Response.RequestSuccessfully);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
