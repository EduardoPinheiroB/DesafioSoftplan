using CSharpFunctionalExtensions;
using Desafio.Application.Models;
using Desafio.Application.UseCases;
using Desafio.Domain.Gateways;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Desafio.Api.UnitTest.Application.UseCases
{
    public class BuscarTaxaJurosUseCaseTest
    {
        private readonly Mock<ILogger<BuscarTaxaJurosUseCase>> loggerMock;
        private readonly Mock<IJuroGateway> juroGatewayMock;
        private readonly BuscarTaxaJurosUseCase buscarTaxaJurosUseCase;

        public BuscarTaxaJurosUseCaseTest()
        {
            loggerMock = new Mock<ILogger<BuscarTaxaJurosUseCase>>();
            juroGatewayMock = new Mock<IJuroGateway>();

            buscarTaxaJurosUseCase = new BuscarTaxaJurosUseCase(loggerMock.Object, juroGatewayMock.Object);
        }

        [Fact]
        public void BuscarTaxaJuro_FluxoSucesso_ResultSuccess()
        {
            //Arrange
            juroGatewayMock.Setup(f => f.BuscarTaxaJuro())
                .Returns(Result.Success<decimal>(0.1M));

            //Act
            var resultado = buscarTaxaJurosUseCase.BuscarTaxaJuro();

            //Assert
            Assert.True(resultado.IsSuccess);
            Assert.Equal(0.1M, resultado.Value.Taxa);
        }

        [Fact]
        public void BuscarTaxaJuro_FluxoInsucesso_ResultFailure()
        {
            //Arrange
            juroGatewayMock.Setup(f => f.BuscarTaxaJuro())
                .Returns(Result.Failure<decimal>("Teste Erro"));

            //Act
            var resultado = buscarTaxaJurosUseCase.BuscarTaxaJuro();

            //Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("Teste Erro", resultado.Error);
        }
    }
}
