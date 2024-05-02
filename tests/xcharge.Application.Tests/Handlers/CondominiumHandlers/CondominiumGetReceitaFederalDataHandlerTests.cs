using System.Net;
using AutoFixture;
using FluentAssertions;
using Moq;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium;
using xcharge.Application.Handlers.CondominiumHandlers;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Application.Interfaces.Services;
using xcharge.Shared.Settings.HttpClientSettings;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Tests.Handlers.CondominiumHandlers;

public class CondominiumGetReceitaFederalDataHandlerTests
{
    private readonly Mock<ICondominiumRepository> _condominiumRepositoryMock;
    private readonly Mock<IHttpClient<string[], CondominiumReceitaFederalDto>> _httpClientMock;
    private readonly Mock<ICondominiumMapper> _condominiumMapperMock;
    private readonly CondominiumGetReceitaFederalDataHandler _condominiumGetReceitaFederalDataHandler;
    private readonly Fixture _fixture;

    public CondominiumGetReceitaFederalDataHandlerTests()
    {
        this._condominiumRepositoryMock = new Mock<ICondominiumRepository>();
        this._httpClientMock = new Mock<IHttpClient<string[], CondominiumReceitaFederalDto>>();
        this._condominiumMapperMock = new Mock<ICondominiumMapper>();
        this._condominiumGetReceitaFederalDataHandler = new CondominiumGetReceitaFederalDataHandler(
            this._httpClientMock.Object
        );
        this._fixture = new();
    }

    [Fact]
    public async void Handler_RequestIsNull_ShouldReturnBadRequest()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();

        // Act
        var result = await this._condominiumGetReceitaFederalDataHandler.Handle(
            null,
            cancellationToken
        );

        // Assert
        result.Data.Should().BeNull();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData([""])]
    [InlineData(null)]
    public async void Handler_ParametersIsNullOrEmpty_ShouldReturnBadRequest(
        params string[] parameters
    )
    {
        // Arrange
        if (parameters is not null && parameters[0] == "")
        {
            parameters = [];
        }

        var cancellationToken = this._fixture.Create<CancellationToken>();
        var condominiumGetReceitaFederalDataQuery = this
            ._fixture.Build<CondominiumGetReceitaFederalDataQuery>()
            .With(x => x.Parameters, parameters)
            .Create();

        // Act
        var result = await this._condominiumGetReceitaFederalDataHandler.Handle(
            condominiumGetReceitaFederalDataQuery,
            cancellationToken
        );

        // Assert
        result.Data.Should().BeNull();
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(Response.RequestFailed);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async void Handler_Success_ShouldReturnOk()
    {
        // Arrange
        var cancellationToken = this._fixture.Create<CancellationToken>();
        var condominiumGetReceitaFederalDataQuery =
            this._fixture.Create<CondominiumGetReceitaFederalDataQuery>();
        var condominiumReceitaFederalDto = this._fixture.Create<CondominiumReceitaFederalDto>();

        this._httpClientMock.Setup(x =>
            x.SendAsync(It.IsAny<string[]>(), It.IsAny<HttpClientSettingsEnum>())
        )
            .ReturnsAsync(condominiumReceitaFederalDto);

        // Act
        var result = await this._condominiumGetReceitaFederalDataHandler.Handle(
            condominiumGetReceitaFederalDataQuery,
            cancellationToken
        );

        // Assert
        result.Data.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Message.Should().Be(Response.RequestSuccessfully);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
