using System.Net;
using AutoFixture;
using FluentAssertions;
using Moq;
using xcharge.Application.CQS.Commands.CondominiumCommand;
using xcharge.Application.Handlers.CondominiumHandlers;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Application.Tests.FakeData;
using xcharge.Domain.Entities;
using xcharge.Shared.Validations;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Tests.Handlers.CondominiumHandlers;

public class CondominiumCreateHandlerTests
{
    private readonly Mock<ICondominiumRepository> _condominiumRepositoryMock;
    private readonly Mock<IValidator> _validatorMock;
    private readonly Mock<ICondominiumMapper> _condominiumMapperMock;
    private readonly CondominiumCreateHandler _condominiumCreateHandler;
    private readonly Fixture _fixture;

    public CondominiumCreateHandlerTests()
    {
        this._condominiumRepositoryMock = new Mock<ICondominiumRepository>();
        this._validatorMock = new Mock<IValidator>();
        this._condominiumMapperMock = new Mock<ICondominiumMapper>();
        this._condominiumCreateHandler = new CondominiumCreateHandler(
            this._condominiumRepositoryMock.Object,
            this._validatorMock.Object,
            this._condominiumMapperMock.Object
        );
        this._fixture = new();
    }

    [Fact]
    public async void Handler_RequestIsNull_ShouldReturnBadRequest()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();

        // Act
        var result = await this._condominiumCreateHandler.Handle(null, cancellationToken);

        // Assert
        result.Data.Should().BeEmpty();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async void Handler_CnpjIsInvalid_ShouldReturnBadRequest()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();
        var invalidCnpj = "12345677654321";

        var condominiumCreateCommand = this
            ._fixture.Build<CondominiumCreateCommand>()
            .With(x => x.Cnpj, invalidCnpj)
            .Create();

        // Act
        var result = await this._condominiumCreateHandler.Handle(
            condominiumCreateCommand,
            cancellationToken
        );

        // Assert
        result.Data.Should().BeEmpty();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        result.Errors.Should().Contain(x => x.Message == Response.InvalidCnpj);
        result.Errors.Should().HaveCount(1);
    }

    [Fact]
    public async void Handler_Success_ShouldReturnOk()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();
        var validCnpj = "76472312000160";

        var condominiumCreateCommand = this
            ._fixture.Build<CondominiumCreateCommand>()
            .With(x => x.Cnpj, validCnpj)
            .Create();

        var condominium = EntityBuilder.CondominiumBuilder();

        this._condominiumMapperMock.Setup(x => x.Map(It.IsAny<CondominiumCreateCommand>()))
            .Returns(condominium);

        this._condominiumRepositoryMock.Setup(x => x.Create(It.IsAny<Condominium>()))
            .ReturnsAsync(Guid.NewGuid());

        // Act
        var result = await this._condominiumCreateHandler.Handle(
            condominiumCreateCommand,
            cancellationToken
        );

        // Assert
        result.Data.Should().NotBeEmpty();
        result.IsSuccess.Should().BeTrue();
        result.Message.Should().Be(Response.CreatedSuccessfully);
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}
