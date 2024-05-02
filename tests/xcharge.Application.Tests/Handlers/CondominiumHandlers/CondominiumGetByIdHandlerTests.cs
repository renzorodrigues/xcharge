using System.Net;
using AutoFixture;
using FluentAssertions;
using Moq;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Handlers.CondominiumHandlers;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Application.Tests.FakeData;
using xcharge.Domain.Entities;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Tests.Handlers.CondominiumHandlers;

public class CondominiumGetByIdHandlerTests
{
    private readonly Mock<ICondominiumRepository> _condominiumRepositoryMock;
    private readonly Mock<ICondominiumMapper> _condominiumMapperMock;
    private readonly CondominiumGetByIdHandler _condominiumGetByIdHandler;
    private readonly Fixture _fixture;

    public CondominiumGetByIdHandlerTests()
    {
        this._condominiumRepositoryMock = new Mock<ICondominiumRepository>();
        this._condominiumMapperMock = new Mock<ICondominiumMapper>();
        this._condominiumGetByIdHandler = new CondominiumGetByIdHandler(
            this._condominiumRepositoryMock.Object,
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
        var result = await this._condominiumGetByIdHandler.Handle(null, cancellationToken);

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
        var condominiumGetByIdQuery = this
            ._fixture.Build<CondominiumGetByIdQuery>()
            .With(x => x.Id, Guid.Empty)
            .Create();

        var cancellationToken = this._fixture.Create<CancellationToken>();

        // Act
        var result = await this._condominiumGetByIdHandler.Handle(
            condominiumGetByIdQuery,
            cancellationToken
        );

        // Assert
        result.Data.Should().BeNull();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async void Handler_CondominiumIsNull_ShouldReturnNotFound()
    {
        // Arrange
        var condominiumGetByIdQuery = this._fixture.Create<CondominiumGetByIdQuery>();
        var cancellationToken = this._fixture.Create<CancellationToken>();

        Condominium condominium = null;

        this._condominiumRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(condominium);

        // Act
        var result = await this._condominiumGetByIdHandler.Handle(
            condominiumGetByIdQuery,
            cancellationToken
        );

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
        var condominiumGetByIdQuery = this._fixture.Create<CondominiumGetByIdQuery>();
        var cancellationToken = this._fixture.Create<CancellationToken>();
        var condominiumGetByIdDto = this._fixture.Create<CondominiumGetByIdDto>();

        Condominium condominium = EntityBuilder.CondominiumBuilder();

        this._condominiumRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(condominium);

        this._condominiumMapperMock.Setup(x => x.Map(It.IsAny<Condominium>()))
            .Returns(condominiumGetByIdDto);

        // Act
        var result = await this._condominiumGetByIdHandler.Handle(
            condominiumGetByIdQuery,
            cancellationToken
        );

        // Assert
        result.Data.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Message.Should().Be(Response.RequestSuccessfully);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
