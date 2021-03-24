using CSharpFunctionalExtensions;
using Desafio.Application.Models;
using Desafio.Application.UseCases;
using Desafio.Domain.Gateways;
using Desafio.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Desafio.Api.UnitTest.Application.UseCases
{
    public class CalcularTaxaJurosUseCaseTest
    {
        private readonly Mock<ILogger<CalcularTaxaJurosUseCase>> loggerMock;
        private readonly Mock<IJuroGateway> juroGatewayMock;
        private readonly CalcularTaxaJurosUseCase calcularTaxaJurosUseCase;

        public CalcularTaxaJurosUseCaseTest()
        {
            loggerMock = new Mock<ILogger<CalcularTaxaJurosUseCase>>();
            juroGatewayMock = new Mock<IJuroGateway>();

            calcularTaxaJurosUseCase = new CalcularTaxaJurosUseCase(loggerMock.Object, juroGatewayMock.Object);
        }

        [Fact]
        public void CalcularTaxaJuros_FluxoSucesso_ResultSuccess()
        {
            //Arrange
            juroGatewayMock.Setup(f => f.ConsultarApiTaxaJuro())
                .ReturnsAsync(Result.Success<Taxa>(new Taxa(0.1M)));

            //Act
            var resultado = calcularTaxaJurosUseCase.CalcularTaxaJuros(2, 1000);
            resultado.Wait();

            //Assert
            Assert.True(resultado.Result.IsSuccess);
            Assert.Equal(1210.0M, resultado.Result.Value);
        }

        [Fact]
        public void CalcularTaxaJuros_FluxoInsucesso_ResultFailure()
        {
            //Arrange
            juroGatewayMock.Setup(f => f.ConsultarApiTaxaJuro())
                .ReturnsAsync(Result.Failure<Taxa>("Teste Erro"));

            //Act
            var resultado = calcularTaxaJurosUseCase.CalcularTaxaJuros(2, 1000);
            resultado.Wait();

            //Assert
            Assert.True(resultado.Result.IsFailure);
            Assert.Equal("Teste Erro", resultado.Result.Error);
        }
    }
}
