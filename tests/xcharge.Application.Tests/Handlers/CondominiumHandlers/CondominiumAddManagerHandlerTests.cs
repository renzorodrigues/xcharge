using System.Net;
using AutoFixture;
using FluentAssertions;
using Moq;
using xcharge.Application.CQS.Commands.CondominiumCommand;
using xcharge.Application.Handlers.CondominiumHandlers;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Application.Tests.FakeData;
using xcharge.Domain.Entities;
using xcharge.Shared.Validations;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Tests.Handlers.CondominiumHandlers;

public class CondominiumAddManagerHandlerTests
{
    private readonly Mock<ICondominiumRepository> _condominiumRepositoryMock;
    private readonly Mock<IValidator> _validatorMock;
    private readonly CondominiumAddManagerHandler _condominiumAddManagerHandler;
    private readonly Fixture _fixture;

    public CondominiumAddManagerHandlerTests()
    {
        this._condominiumRepositoryMock = new Mock<ICondominiumRepository>();
        this._validatorMock = new Mock<IValidator>();
        this._condominiumAddManagerHandler = new CondominiumAddManagerHandler(
            this._condominiumRepositoryMock.Object,
            this._validatorMock.Object
        );
        this._fixture = new();
    }

    [Fact]
    public async void Handler_RequestIsNull_ShouldReturnBadRequest()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();

        // Act
        var result = await this._condominiumAddManagerHandler.Handle(null, cancellationToken);

        // Assert
        result.Data.Should().BeEmpty();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData("", "970548ca-182d-4ab6-a57d-067f21c59844")]
    [InlineData("e585618b-3d43-4f0d-9735-c9827ecb12d0", "")]
    public async void Handler_CondominiumIdOrUserIdIsEmpty_ShouldReturnBadRequest(
        string id1,
        string id2
    )
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();

        var condominiumId = Guid.TryParse(id1, out _) ? Guid.Parse(id1) : Guid.Empty;
        var userId = Guid.TryParse(id2, out _) ? Guid.Parse(id2) : Guid.Empty;

        var addManagerCommand = this
            ._fixture.Build<AddManagerCommand>()
            .With(x => x.CondominiumId, condominiumId)
            .With(x => x.UserId, userId)
            .Create();

        // Act
        var result = await this._condominiumAddManagerHandler.Handle(
            addManagerCommand,
            cancellationToken
        );

        // Assert
        result.Data.Should().BeEmpty();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async void Handler_CondominiumIsNull_ShouldReturnNotFound()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();
        var addManagerCommand = this._fixture.Create<AddManagerCommand>();

        // Act
        var result = await this._condominiumAddManagerHandler.Handle(
            addManagerCommand,
            cancellationToken
        );

        // Assert
        result.Data.Should().BeEmpty();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.CondominiumNotFound);
        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async void Handler_Success_ShouldReturnOk()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();
        var addManagerCommand = this._fixture.Create<AddManagerCommand>();
        var condominium = EntityBuilder.CondominiumBuilder();

        this._condominiumRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(condominium);

        this._condominiumRepositoryMock.Setup(x => x.Update(It.IsAny<Condominium>()))
            .ReturnsAsync(Guid.NewGuid());

        // Act
        var result = await this._condominiumAddManagerHandler.Handle(
            addManagerCommand,
            cancellationToken
        );

        // Assert
        result.Data.Should().NotBeEmpty();
        result.IsSuccess.Should().BeTrue();
        result.Message.Should().Be(Response.UpdatedSuccessfully);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
