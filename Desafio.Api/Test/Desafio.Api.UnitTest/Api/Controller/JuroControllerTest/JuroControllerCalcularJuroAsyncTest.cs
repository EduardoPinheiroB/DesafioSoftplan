using CSharpFunctionalExtensions;
using Desafio.Api.Controllers;
using Desafio.Application.Interfaces;
using Desafio.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Desafio.Api.UnitTest.Api.Controller.JuroControllerTest
{
    public class JuroControllerCalcularJuroAsyncTest
    {
        private readonly Mock<ILogger<JuroController>> loggerMock;
        private readonly Mock<IBuscarTaxaJurosUseCase> taxaJurosUseCaseMock;
        private readonly Mock<ICalcularTaxaJurosUseCase> calcularTaxaJurosUseCaseMock;
        private readonly JuroController juroController;

        public JuroControllerCalcularJuroAsyncTest()
        {
            this.loggerMock = new Mock<ILogger<JuroController>>();
            this.taxaJurosUseCaseMock = new Mock<IBuscarTaxaJurosUseCase>();
            this.calcularTaxaJurosUseCaseMock = new Mock<ICalcularTaxaJurosUseCase>();

            juroController = new JuroController(loggerMock.Object, taxaJurosUseCaseMock.Object, calcularTaxaJurosUseCaseMock.Object);
        }

        [Fact]
        public void CalculajurosAsync_FluxoSucesso_OkObjectResult()
        {
            //Arrange
            calcularTaxaJurosUseCaseMock.Setup(f => f.CalcularTaxaJuros(It.IsAny<int>(), It.IsAny<decimal>()))
                .ReturnsAsync(Result.Success<decimal>(1000M));

            //Act
            var resultado = juroController.CalculajurosAsync(1000, 2);
            resultado.Wait();

            //Assert
            var tipoResultado = Assert.IsType<OkObjectResult>(resultado.Result);
            Assert.Equal(1000.0M, tipoResultado.Value);
        }

        [Fact]
        public void CalculajurosAsync_FluxoInsucesso_BadRequestObjectResult()
        {
            //Arrange
            calcularTaxaJurosUseCaseMock.Setup(f => f.CalcularTaxaJuros(It.IsAny<int>(), It.IsAny<decimal>()))
                .ReturnsAsync(Result.Failure<decimal>("Teste Erro"));

            //Act
            var resultado = juroController.CalculajurosAsync(1000, 2);
            resultado.Wait();

            //Assert
            var tipoResultado = Assert.IsType<BadRequestObjectResult>(resultado.Result);
            Assert.Equal("Ocorreu uma falha ao processar a requisição", tipoResultado.Value);
        }

        [Fact]
        public void CalculajurosAsync_FluxoExcecao_ObjectResult()
        {
            //Arrange
            calcularTaxaJurosUseCaseMock.Setup(f => f.CalcularTaxaJuros(It.IsAny<int>(), It.IsAny<decimal>()))
                .Throws(new Exception("Teste Excecao"));

            //Act
            var resultado = juroController.CalculajurosAsync(1000, 2);
            resultado.Wait();

            //Assert
            var tipoResultado = Assert.IsType<ObjectResult>(resultado.Result);
            Assert.Equal(StatusCodes.Status500InternalServerError, tipoResultado.StatusCode);
            Assert.Equal("Ocorreu um erro ao processar a requisição.", tipoResultado.Value);
        }
    }
}
